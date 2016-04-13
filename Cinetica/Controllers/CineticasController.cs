using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CineticaApp.Models;

namespace CineticaApp.Controllers
{
    public class CineticasController : ApiController
    {
        private CineticaAppContext db = new CineticaAppContext();

        // GET: api/Cineticas
        public IQueryable<Models.Cinetica> GetCineticas()
        {
            return db.Cineticas;
        }

        // GET: api/Cineticas/5
        [ResponseType(typeof(Models.Cinetica))]
        public IHttpActionResult GetCinetica(int id)
        {
            Models.Cinetica cinetica = db.Cineticas.Find(id);
            if (cinetica == null)
            {
                return NotFound();
            }

            return Ok(cinetica);
        }

        // PUT: api/Cineticas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCinetica(int id, Models.Cinetica cinetica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cinetica.CineticaId)
            {
                return BadRequest();
            }

            db.Entry(cinetica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CineticaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cineticas
        [ResponseType(typeof(Models.Cinetica))]
        public IHttpActionResult PostCinetica(Models.Cinetica cinetica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cineticas.Add(cinetica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cinetica.CineticaId }, cinetica);
        }

        // DELETE: api/Cineticas/5
        [ResponseType(typeof(Models.Cinetica))]
        public IHttpActionResult DeleteCinetica(int id)
        {
            Models.Cinetica cinetica = db.Cineticas.Find(id);
            if (cinetica == null)
            {
                return NotFound();
            }

            db.Cineticas.Remove(cinetica);
            db.SaveChanges();

            return Ok(cinetica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CineticaExists(int id)
        {
            return db.Cineticas.Count(e => e.CineticaId == id) > 0;
        }
    }
}