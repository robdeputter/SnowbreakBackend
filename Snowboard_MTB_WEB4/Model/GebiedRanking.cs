﻿using Snowboard_MTB_WEB4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snowboard_WEB4.Model
{
    public class GebiedRanking
    {
        public int GebiedId { get; set; }
        public int RankingId { get; set; }
        public int Positie { get; set; }

        public Gebied Gebied { get; set; }
        public Ranking Ranking { get; set; }

        protected GebiedRanking()
        {

        }

        public GebiedRanking(Gebied gebied, Ranking ranking, int positie)
        {
            Gebied = gebied;
            Ranking = ranking;

            GebiedId = gebied.Id;
            RankingId = ranking.Id;
            Positie = positie;
            gebied.AddRanking(this);
        }


    }
}
