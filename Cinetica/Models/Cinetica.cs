using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineticaApp.Models
{
    public class Cinetica
    {
        public int CineticaId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public float AccX { get; set; }
        public float AccY { get; set; }
        public float AccZ { get; set; }
        public DateTime Time { get; set; }
    }
}