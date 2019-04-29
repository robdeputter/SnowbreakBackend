using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Model
{
    public class Gebruiker
    {

        #region Properties
        public int GebruikerId { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        public string Familienaam { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsAdmin { get; set; }
        #endregion

        #region Constructors
        public Gebruiker()
        {

        }

        public Gebruiker(string voornaam, string familienaam, string email)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
            Email = email;
            IsAdmin = false;
        } 
        #endregion

    }
}
