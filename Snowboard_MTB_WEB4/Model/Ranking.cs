using Snowboard_WEB4.DTO_s;
using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_MTB_WEB4.Model
{
    public class Ranking
    {
        //attributen
        public int Id { get; set; }
        public string Naam { get; set; }
        public Continent Continent { get; set; }

        //relaties
        public ICollection<GebiedRanking> Gebieden { get; set; }

        protected Ranking()
        {
            Gebieden = new List<GebiedRanking>();
        }

        public Ranking(string naam, Continent continent)
        {
            Naam = naam;
            Continent = continent;
            Gebieden = new List<GebiedRanking>();

        }

        public void AddGebied(Gebied gebied, int positie)
        {
            Gebieden.Add(new GebiedRanking(gebied,this, positie));
        }
        public void RemoveGebied(Gebied gebied)
        {
            Gebieden.Remove(Gebieden.SingleOrDefault(g => g.GebiedId == gebied.Id));
        }
    }
}
