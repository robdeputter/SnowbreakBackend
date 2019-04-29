using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.DTO_s
{
    public class EvenementDTO
    {
        [Required(ErrorMessage = "Naam is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(2, ErrorMessage = "Naam moet minstens 2 karakters bevatten!")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Beschrijving is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(2, ErrorMessage = "Beschrijving moet minstens 2 karakters bevatten!")]
        public string Beschrijving { get; set; }

        [Required(ErrorMessage = "Startdatum is verplicht")]
        [DataType(DataType.DateTime)]
        public DateTime StartDatum { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EindDatum { get; set; }

        [Required(ErrorMessage = "Gebied is verplicht is verplicht")]
        public int gebiedID { get; set; }


    }
}
