using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snowboard_MTB_WEB4.Model;
using Snowboard_WEB4.DTO_s;
using Snowboard_WEB4.Model;

namespace Snowboard_WEB4.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class GebiedController : ControllerBase
    {
        private readonly IGebiedRepository _gebiedRepository;
        private readonly IEvenementRepository _evenementRepository;
        private readonly IRankingRepository _rankingRepository;

        public GebiedController(IGebiedRepository gebiedRepository, IEvenementRepository evenementRepository
            , IRankingRepository rankingRepository)
        {
            _gebiedRepository = gebiedRepository;
            _evenementRepository = evenementRepository;
            _rankingRepository = rankingRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Gebied> GetAll()
        {
            return _gebiedRepository.GetAll();

        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Gebied> GetGebied(int id)
        {
            Gebied gebied = _gebiedRepository.GetById(id);
            if (gebied != null)
            {
                return gebied;
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<Gebied> PostGebied(GebiedDTO gebiedDTO)
        {
            try
            {
                Gebied gebied = new Gebied(gebiedDTO.Naam, gebiedDTO.Land,
                    gebiedDTO.Continent, gebiedDTO.Lengtegraad, gebiedDTO.Breedtegraad, gebiedDTO.AantalKmPiste, gebiedDTO.HoogteGebied);

                _gebiedRepository.Add(gebied);
                _gebiedRepository.SaveChanges();
                return CreatedAtAction(nameof(GetGebied), new { id = gebied.Id }, gebied);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public IActionResult PutGebied(int id, Gebied gebied)
        {
            try
            {
                if (id != gebied.Id)
                {
                    return BadRequest();
                }
                _gebiedRepository.Update(gebied);
                _gebiedRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public ActionResult<Gebied> DeleteGebied(int id)
        {
            Gebied gebied = _gebiedRepository.GetById(id);
            bool gebiedInRanking = false;
            if (gebied == null)
            {
                return NotFound();
            }
            _rankingRepository.GetAll().ToList().ForEach(ranking =>
            {
                if (ranking.Gebieden.FirstOrDefault(gebiedr => gebiedr.GebiedId == id) != null)
                {
                    gebiedInRanking = true;
                }
            });

            if (_evenementRepository.GetAll().FirstOrDefault(evenement => evenement.Gebied.Id == id) != null || gebiedInRanking)
            {
                return BadRequest();
            }

           
            
            else
            {
                _gebiedRepository.Delete(gebied);
                _gebiedRepository.SaveChanges();
                return gebied;
            }
            
        }
    }
}