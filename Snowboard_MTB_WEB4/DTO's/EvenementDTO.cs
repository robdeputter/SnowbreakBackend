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
        [Required]
        public string Naam { get; set; }

        [Required]
        public string Beschrijving { get; set; }

        [Required]
        public DateTime StartDatum { get; set; }

        public DateTime? EindDatum { get; set; }

        [Required]
        public Gebied Gebied { get; set; }
    }
}
