using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snowboard_MTB_WEB4.Model;

namespace Snowboard_MTB_WEB4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IRankingRepository _rankingRepository;

        public RankingController(IRankingRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
        }

        

    }
}