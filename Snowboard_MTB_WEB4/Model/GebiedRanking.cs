using Newtonsoft.Json;
using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Model
{
    public class GebiedRanking
    {
        #region Properties

        [JsonIgnore]
        public int GebiedId { get; set; }
        [JsonIgnore]
        public int RankingId { get; set; }

        [JsonProperty]
        public int Positie { get; set; } 
      
        [JsonProperty]
        public Gebied Gebied { get; set; }
        #endregion


        #region Constructors
        protected GebiedRanking()
        {

        }

        public GebiedRanking(Gebied gebied, Ranking ranking, int positie)
        {
            Gebied = gebied;
            GebiedId = gebied.Id;
            RankingId = ranking.Id;
            Positie = positie;
        } 
        #endregion


    }
}
