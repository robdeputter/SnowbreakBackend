using Snowboard_MTB_WEB4.Model;
using Snowboard_WEB4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.DTO_s
{
    public class RankingDTO
    {
        //attributen
        [Required(ErrorMessage = "Naam is verplicht")]
        [DataType(DataType.Text)]
        [MinLength(2, ErrorMessage = "Naam moet minstens 2 karakters bevatten!")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Continent is verplicht")]
        public Continent Continent { get; set; }

        //HIER MOET NOG IETS KOMEN VOOR GEBIEDEN!
        [Required(ErrorMessage = "Gebieden zijn verplicht")]
        public IEnumerable<GebiedRankingDTO> Gebieden { get; set; }

}
}
