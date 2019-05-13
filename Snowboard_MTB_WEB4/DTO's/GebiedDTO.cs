using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.DTO_s
{
    public class GebiedDTO
    {
        //private string _naam;
        //private string _land;
        //private string _lengtegraad;
        //private string _breedtegraad;
        //private int _aantalKmPiste;
        //private int _hoogteGebied;
        [Required(ErrorMessage = "Naam is verplicht!")]
        [DataType(DataType.Text)]
        [MinLength(2, ErrorMessage = "Naam moet minstens 2 karakters bevatten!")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Land is verplicht!")]
        [DataType(DataType.Text)]
        [MinLength(2, ErrorMessage = "Land moet minstens 2 karakters bevatten!")]
        public string Land { get; set; }

        [Required(ErrorMessage = "Lengtegraad is verplicht!")]
        public double Lengtegraad { get; set; }

        [Required(ErrorMessage = "Breedtegraad is verplicht!")]
        public double Breedtegraad { get; set; }

        [Required(ErrorMessage = "Aantal km piste is verplicht!")]
        [Range(0, int.MaxValue, ErrorMessage = "Aantal km piste moet meer dan 0 zijn!")]
        public int AantalKmPiste { get; set; }


        [Required(ErrorMessage = "Hoogte gebied is verplicht!")]
        [Range(0, int.MaxValue, ErrorMessage = "Hoogte gebied moet meer dan 0 zijn!")]
        public int HoogteGebied { get; set; }

        [Required(ErrorMessage = "Continent is verplicht!")]
        public Continent Continent { get; set; }
    }
}
