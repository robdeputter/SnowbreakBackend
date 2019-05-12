using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_MTB_WEB4.Model
{
    public class Gebied
    {

        #region Backing fields
        private string _naam;
        private string _land;
        private double _lengtegraad;
        private double _breedtegraad;
        private int _aantalKmPiste;
        private int _hoogteGebied;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Naam {
            get {
                return _naam;
            }
            set {
                if (value == null)
                {
                    throw new ArgumentException("Naam mag niet leeg zijn!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Naam moet minstens 2 karakters bevatten!");
                }
                _naam = value;

            }
        }
        public string Land {
            get {
                return _land;  
            }
            set {
                if(value == null)
                {
                    throw new ArgumentException("Land mag niet leeg zijn!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Naam moet minstens 2 karakters bevatten!");
                }
                _land = value;

            } }
        public double LengteGraad {
            get {
                return _lengtegraad;
            }
            set {
                _lengtegraad = value;
            }
        }
        public double Breedtegraad {
            get {
                return _breedtegraad;
            }
            set {
                _breedtegraad = value;
            }
        }
        public int AantalKmPiste {
            get {
                return _aantalKmPiste;
            }
            set {
                if(value <= 0)
                {
                    throw new ArgumentException("Het aantal km piste moet groter zijn dan 0!");
                }
                _aantalKmPiste = value;
            }
        }
        public int HoogteGebied {
            get {
                return _hoogteGebied;
            }
            set {
                if(value <= 0)
                {
                    throw new ArgumentException("Hoogte gebied moet groter zijn dan 0!");
                }
                _hoogteGebied = value;
            }
        }
        public Continent Continent { get; set; }
        #endregion


        #region Constructors
        protected Gebied()
        {

        }

        public Gebied(string naam, string land, Continent continent, double lengtegraad, double breedtegraad, int aantalKmPiste, int hoogteGebied)
        {
            Naam = naam;
            Land = land;
            this.Continent = continent;
            LengteGraad = lengtegraad;
            Breedtegraad = breedtegraad;
            AantalKmPiste = aantalKmPiste;
            HoogteGebied = hoogteGebied;
        } 
        #endregion

    }
}
