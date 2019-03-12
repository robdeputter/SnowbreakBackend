using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_MTB_WEB4.Model
{
    public class Gebied
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Land { get; set; }
        public string LengteGraad { get; set; }
        public string Breedtegraad { get; set; }
        public int AantalKmPiste { get; set; }
        public int HoogteGebied { get; set; }

        public ICollection<GebiedRanking> Rankings { get; set; }

        protected Gebied()
        {
            Rankings = new List<GebiedRanking>();
        }

        public Gebied(string naam, string land,string lengtegraad, string breedtegraad, int aantalKmPiste, int hoogteGebied)
        {
            Naam = naam;
            Land = land;
            LengteGraad = lengtegraad;
            Breedtegraad = breedtegraad;
            AantalKmPiste = aantalKmPiste;
            HoogteGebied = hoogteGebied;
            Rankings = new List<GebiedRanking>();
        }

    }
}
