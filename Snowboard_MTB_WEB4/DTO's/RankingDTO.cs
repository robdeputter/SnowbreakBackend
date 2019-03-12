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
        [Required]
        public string Naam { get; set; }
        [Required]
        public Continent Continent { get; set; }

        //HIER MOET NOG IETS KOMEN VOOR GEBIEDEN!
        
    }
}
