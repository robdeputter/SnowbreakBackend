using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_MTB_WEB4.Model
{
    public class Evenement
    {
        #region Backing fields
        private string _naam;
        private string _beschrijving;
        private DateTime _startdatum;
        private DateTime _einddatum;
        private Gebied _gebied;
        #endregion

        #region Constructors
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
        public string Beschrijving {
            get {
                return _beschrijving;
            }
            set {
                if (value == null)
                {
                    throw new ArgumentException("Beschrijving mag niet leeg zijn!");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Beschrijving moet minstens 2 karakters bevatten!");
                }
                _beschrijving = value;
            }
        }
        public DateTime StartDatum {
            get {
                return _startdatum;
            }
            set {
                if (value == null)
                {
                    throw new ArgumentException("Startdatum mag niet leeg zijn!");
                }
                if (DateTime.Today > value)
                {
                    throw new ArgumentException("Startdatum moet in de toekomst liggen!");
                }
                _startdatum = value;
            }
        }
        public DateTime? EindDatum {
            get {
                return _einddatum;
            }
            set {
                if (value < StartDatum)
                {
                    throw new ArgumentException("Einddatum moet na de startdatum liggen!");
                }
                if (value < DateTime.Today)
                {
                    throw new ArgumentException("Eindatum moet in het verleden liggen.");
                }
                _einddatum = value.Value;
            }
        }
        public int NrOfDays => EindDatum == null ? 1 : CountNumberOfDays(StartDatum, EindDatum.Value);

        public Gebied Gebied {
            get {
                return _gebied;
            }
            set {
                _gebied = value ?? throw new ArgumentException("Gebied mag niet leeg zijn!");
            }
        }
        #endregion

        protected Evenement()
        {

        }


        public Evenement(string naam, string beschrijving, DateTime startDatum, DateTime? eindDatum, Gebied gebied)
        {
            Naam = naam;
            Beschrijving = beschrijving;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Gebied = gebied;
            //NrOfDays = eindDatum == null ? 1 : CountNumberOfDays(StartDatum, EindDatum.Value);
        }
        #endregion

        #region Methodes
        public int CountNumberOfDays(DateTime startDatum, DateTime eindDatum)
        {
            TimeSpan verschil = eindDatum - startDatum;
            return verschil.Days;
        }
        #endregion


    }
}
