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
        private string _naam;

        #region Properties
        public int Id { get; set; }
        public string Naam {
            get {
                return _naam;
            } set {
                if(value == null)
                {
                    throw new ArgumentException("Naam mag niet leeg zijn!");
                }
                if(value.Length < 2)
                {
                    throw new ArgumentException("Naam moet minstens 2 karakters bevatten");
                }
                _naam = value;
            } }
        public Continent Continent { get; set; }
        #endregion


        #region Relaties
        public ICollection<GebiedRanking> Gebieden { get; set; }
        #endregion

        #region Constructors
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
        #endregion

        #region Methodes
        public void AddGebied(Gebied gebied, int positie)
        {
            Gebieden.Add(new GebiedRanking(gebied, this, positie));
        }
        public void RemoveGebied(Gebied gebied)
        {
            Gebieden.Remove(Gebieden.SingleOrDefault(g => g.GebiedId == gebied.Id));
        } 
        #endregion
    }
}
