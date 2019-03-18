using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_MTB_WEB4.Model
{
    public class Evenement
    {
        //attributen
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime? EindDatum { get; set; }
        public int NrOfDays { get; set; }
        public Gebied Gebied { get; set; }

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
            NrOfDays = eindDatum == null ? 1 : CountNumberOfDays(StartDatum, EindDatum.Value);
        }
        
        public int CountNumberOfDays(DateTime startDatum, DateTime eindDatum)
        {
            TimeSpan verschil = eindDatum - startDatum;
            return verschil.Days;
        }


    }
}
