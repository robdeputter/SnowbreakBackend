using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snowboard_MTB_WEB4.Model;
using Snowboard_WEB4.DTO_s;

namespace Snowboard_MTB_WEB4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class RankingController : ControllerBase
    {
        private readonly IRankingRepository _rankingRepository;

        public RankingController(IRankingRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Ranking> GetRanking(int id)
        {
            Ranking ranking = _rankingRepository.GetById(id);
            if (ranking != null)
            {
                return ranking;
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Ranking> PostRanking(RankingDTO rankingDTO)
        {
            Ranking ranking = new Ranking(rankingDTO.Naam, rankingDTO.Continent);

            _rankingRepository.Add(ranking);
            _rankingRepository.SaveChanges();
            return CreatedAtAction(nameof(GetRanking), new { id = ranking.Id }, ranking);
        }

        [HttpPut("{id}")]
        public IActionResult PutRanking(int id, Ranking ranking)
        {
            if (id != ranking.Id)
            {
                return BadRequest();
            }
            _rankingRepository.Update(ranking);
            _rankingRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Ranking> DeleteRanking(int id)
        {
            Ranking ranking = _rankingRepository.GetById(id);
            if (ranking == null)
            {
                return NotFound();
            }
            _rankingRepository.Delete(ranking);
            _rankingRepository.SaveChanges();
            return ranking;
        }



    }
}