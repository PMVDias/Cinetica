using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CineticaApp.Models;
using System.Xml.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mail;

namespace CineticaApp.Controllers
{
    public class HomeController : Controller
    {
        private CineticaAppContext db = new CineticaAppContext();

        // GET: Home
        public ActionResult Index()
        {
            Post post = new Post();
            var posts = post.GetListofPosts().OrderByDescending(x => x.Date).ToList<Post>();
            ViewBag.Work = "active";
            return View(posts);
        }


        // GET: Lab
        public ActionResult Lab()
        {
            List<Post> listPosts = new List<Post>();

            listPosts = GetPostsFromInstagram();

            listPosts.AddRange(GetPostsFromTumblr());

            ViewBag.Message = "Lab";
            ViewBag.Lab = "active";

            return View(listPosts.OrderByDescending(x => x.Date).ToList<Post>());

        
        }

        public List<Post> GetPostsFromTumblr()
        {
            string url = "http://carlosuncut.tumblr.com/api/read";

            var webClient = new WebClient();

            string result = webClient.DownloadString(url);

            XDocument document = XDocument.Parse(result);

            return (from descendant in document.Descendants("post").Where(x => (string)x.Attribute("type") == "photo")
                         select new Post()
                         {
                             Description = CineticaApp.Helpers.HtmlRemoval.StripTagsRegex(descendant.Element("photo-caption").Value),
                             ImageLocation = descendant.Elements("photo-url").Single(x => (string)x.Attribute("max-width") == "500").Value,
                             Tags = "#" + String.Join(" #", descendant.Elements("tag").Select(x => x.Value)),
                             Url = descendant.Attribute("url").Value,
                             Date = Convert.ToDateTime(descendant.Attribute("date-gmt").Value)
                         }).ToList();
        }

        public List<Post> GetPostsFromInstagram()
        {
            string url = "https://www.instagram.com/cpvalente/media/";

            var webClient = new WebClient();

            string json = webClient.DownloadString(url);

            JObject rss = JObject.Parse(json);

            return (from item in rss["items"]
                    select new Post()
                    {
                        Description = (string)item["caption"]["text"],
                        ImageLocation = (string)item["images"]["standard_resolution"]["url"],
                        Url = (string)item["link"],
                        Date = new DateTime(1970, 1, 1).AddSeconds((long)item["caption"]["created_time"])
                    }).ToList();
        }

        public List<Post> GetPostsFromInstagram2()
        {
            string url = "http://widget.websta.me/rss/n/cpvalente";

            var webClient = new WebClient();

            string feed = webClient.DownloadString(url);

            XDocument document = XDocument.Parse(feed);

            return (from descendant in document.Descendants("item")
                    select new Post()
                    {
                        Description = CineticaApp.Helpers.HtmlRemoval.StripTagsRegex(descendant.Element("title").Value),
                        ImageLocation = descendant.Element("image").Value,
                        Tags = "#" + CineticaApp.Helpers.HtmlRemoval.StripTagsRegex(String.Join(" #", descendant.Elements("description").Select(x => x.Value))),
                        Url = descendant.Element("link").Value

                    }).ToList();
        }


        // GET: Home
        public ActionResult PostDetails(int? id)
        {
            Post post = new Post();
            var postDetail = post.GetListofPosts().Where(x => x.PostId == id).FirstOrDefault();

            //if(id == 1)
            //    return View("PostDetail1");
            //else
                return View(postDetail);
        }

        public async System.Threading.Tasks.Task<ActionResult> SendEmail(string name, string phone, string email, string message)
        {
            try
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var emailMessage = new MailMessage();
                emailMessage.To.Add(new MailAddress("mail@carlosvalente.net"));  // replace with valid value 
                emailMessage.From = new MailAddress(email);  // replace with valid value
                emailMessage.Subject = "Portfolio Contact";
                emailMessage.Body = string.Format(body, name, email, message);
                emailMessage.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(emailMessage);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
          
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        // GET: Home
        public ActionResult Items()
        {
            return View(db.Cineticas.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Cinetica cinetica = db.Cineticas.Find(id);
            if (cinetica == null)
            {
                return HttpNotFound();
            }
            return View(cinetica);
        }

        // GET: About
        public ActionResult About()
        {
            ViewBag.Message = "About";
            ViewBag.About = "active";
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";
            ViewBag.Contact = "active";
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CineticaId,UserId,Name,AccX,AccY,AccZ,Time")] Models.Cinetica cinetica)
        {
            if (ModelState.IsValid)
            {
                db.Cineticas.Add(cinetica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cinetica);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Cinetica cinetica = db.Cineticas.Find(id);
            if (cinetica == null)
            {
                return HttpNotFound();
            }
            return View(cinetica);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CineticaId,UserId,Name,AccX,AccY,AccZ,Time")] Models.Cinetica cinetica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinetica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinetica);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Cinetica cinetica = db.Cineticas.Find(id);
            if (cinetica == null)
            {
                return HttpNotFound();
            }
            return View(cinetica);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Cinetica cinetica = db.Cineticas.Find(id);
            db.Cineticas.Remove(cinetica);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
