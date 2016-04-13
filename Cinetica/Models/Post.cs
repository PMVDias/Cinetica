using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineticaApp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body1 { get; set; }
        public string Body2 { get; set; }
        public string Body3 { get; set; }

        public string ImageLocation { get; set; }
        public string ImageThumb { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public string Tags { get; set; }
        public string Url { get; set; }

        public List<Post> GetListofPosts()
        {
            var posts = new List<Post>();


            posts.Add(new Post
            {
                PostId = 1,
                Title = "C I N E T I C A",
                Description = "KINETIC DRAWING MACHINE",
                Body1 = @"Cinetica is a drawing machine that aims towards a “synesthetic” artwork. A period of time can be plotted into a kinetic drawing: “this is how commuting in London feels like” or “this is how the Pixies concert was like”. The result are sketches that loosely resemble Japanese sumi-e paintings.
                        The visible project is a circular platform that hangs in mid-air inside this wooden cube. In the platform a ball of ink rolls around as the platform moves, leaving a trail – a drawing – of this interaction, this drawing is the final product. Behind two distinct apps on an android phone and on a computer to facilitate technical aspects, the control part is very minimalistic on an attempt to centre focus on the natural interaction rather than on the control side. 
                        The machine is made of wood and string recovering a classical aesthetic of mathematical (technological) pursuit of natural beauty. 
                        ",
                ImageLocation = "/Content/img/work/cinetica.png",
                ImageThumb = "/Content/img/work/cinetica_thumb.png",
                Date = new DateTime(2016,3,23),
                Url = "",
                Tags = "Creative Coding · Physical Computing",
            });

            posts.Add(new Post
            {
                PostId = 3,
                Title = "C O R A L  D R A W",
                Description = "",
                Body1 = @"Loosely based on leaf venation growth, Coral Draw is a play on bending organic behaviors into becoming artists of its own form.
                        Given a base image containing basic contours and colour palette, these agents grow into.
                        ",
                ImageLocation = "/Content/img/work/coral.png",
                ImageThumb = "/Content/img/work/coral draw_thumb.png",
                Tags = "Creative Coding · Emergent Complexity · Processing",
                Url = "",
                Date = new DateTime(2016, 1, 12)
            });

            posts.Add(new Post
            {
                PostId = 4,
                Title = "H I D D E N  W O R L D S",
                Description = "CONTEMPLATING DIGITAL SKIES",
                Body1 = @"Hidden Worlds is my final project for the Creative Coding class. This comes to end a year of explorations on coding, of pain, and of getting used to mathematics (How I stopped worrying in learned to love the beast).
                          A petri dish exhibits intricate bacteria / galaxy structures who invite the spectator into its world as a flower blossoming, calling for contemplation and deep observation. These structures exist in a limbo between digital and merely invisible, however environment disturbances affect its composition revealing its digital nature.
                          The proposal for this installation is that of exploring emergent intelligence from low level simple interaction rules, inspired by the events of the discovery of microbiology and atoms, it feels fascinating to think of all the hidden layers of existence that surrounds us while we stand unaware. The guiding motto for the installation is “Contemplating digital skies”: a new aesthetic proposition on finding a language to reveal yet another layer of invisible hyper-digital creatures. Its meaning and beauty.
                            ",
                ImageLocation = "/Content/img/work/hiddenwords.png",
                Tags = "Creative Coding · Emergent Complexity",
                ImageThumb = "/Content/img/work/hiddenWorlds_thumb.jpg",
                Date = new DateTime(2016, 4, 1)
            });

            posts.Add(new Post
            {
                PostId = 5,
                Title = "S T U B B O R N E S S  O F  V I S I O N",
                Description = "COMPOSITING VISION SYSTEMS FOR ALIENS",
                Body1 = @"stubborn |ˈstʌbən|
                        adjective
                        having or showing dogged determination not to change one's attitude or position on something, especially in spite of good reasons to do so.

                        Stubborness of Vision is a video installation that explores ideas on environment perception and interpretation.

                        The proposal is to create a vision system for the Martian tripods - the “war machines” - which the Martians that the Wells describes as “sluggard creatures” used on colonizing other worlds. In this interpretation the focus is on aspects of colonialism and dependency on technocracies to create a visualization that transpires the way our “world” is seen by an artificial / alien intelligence. The Martians trust these tripods to perceive and affect the world on their behalf, but how would a race with a different genealogy be able to correctly interpret the information that captures?

                        The project plays with ideas of abstraction and misunderstanding of the human form. The result is a composition that translates images from a camera in real time and imposes its own rules into the output, the “Stubbornness of Vision”, on an ever-flowing abstract environment.

                        ",
                ImageLocation = "/Content/img/work/stubborness.png",
                ImageThumb = "/Content/img/work/stubborness_thumb.png",
                Tags = "Creative Coding · Computer Vision · The War of the Worlds",
                Date = new DateTime(2016, 1, 5)
            });
            
            return posts;
        }
    }
}