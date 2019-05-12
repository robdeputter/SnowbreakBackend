using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.DTO_s
{
    public class GebiedRankingDTO
    {
        [Required(ErrorMessage = "Positie is verplicht!")]
        [Range(1, 10, ErrorMessage = "Positie moet tussen 1 en 10 liggen!")]
        public int Positie { get; set; }

        [Required(ErrorMessage = "Gebied is verplicht!")]
        public int GebiedId { get; set; }
    }
}
