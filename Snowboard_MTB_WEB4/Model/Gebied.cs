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
        public string Coördinaten { get; set; }
        public int AantalKmPiste { get; set; }
        public int HoogteGebied { get; set; }

        public ICollection<GebiedRanking> Rankings { get; set; }

        public Gebied()
        {
            Rankings = new List<GebiedRanking>();
        }

        public Gebied(string naam, string land, string coördinaten, int aantalKmPiste, int hoogteGebied)
        {
            Naam = naam;
            Land = land;
            Coördinaten = coördinaten;
            AantalKmPiste = aantalKmPiste;
            HoogteGebied = hoogteGebied;
            Rankings = new List<GebiedRanking>();
        }

    }
}
