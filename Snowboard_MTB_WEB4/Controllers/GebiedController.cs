using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snowboard_MTB_WEB4.Model;
using Snowboard_WEB4.DTO_s;
using Snowboard_WEB4.Model;

namespace Snowboard_WEB4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebiedController : ControllerBase
    {
        private readonly IGebiedRepository _gebiedRepository;

        public GebiedController(IGebiedRepository gebiedRepository)
        {
            _gebiedRepository = gebiedRepository;
        }

        [HttpGet]
        public IEnumerable<Gebied> GetAll()
        {
            return _gebiedRepository.GetAll();

        }

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

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            if (gebied == null)
            {
                return NotFound();
            }
            _gebiedRepository.Delete(gebied);
            _gebiedRepository.SaveChanges();
            return gebied;
        }
    }
}