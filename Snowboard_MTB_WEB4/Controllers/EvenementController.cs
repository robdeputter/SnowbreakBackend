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
    public class EvenementController : ControllerBase
    {
        private readonly IEvenementRepository _evenementRepository;

        public EvenementController(IEvenementRepository evenementRepository)
        {
            _evenementRepository = evenementRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Evenement> GetEvenement(int id)
        {
            Evenement evenement = _evenementRepository.GetById(id);
            if (evenement != null)
            {
                return evenement;
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Evenement> PostEvenement(EvenementDTO evenementDTO)
        {
            Evenement evenement = new Evenement(evenementDTO.Naam, evenementDTO.Beschrijving,
                evenementDTO.StartDatum, evenementDTO?.EindDatum, evenementDTO.Gebied);

            _evenementRepository.Add(evenement);
            _evenementRepository.SaveChanges();
            return CreatedAtAction(nameof(GetEvenement), new { id = evenement.Id }, evenement);
        }

        [HttpPut("{id}")]
        public IActionResult PutEvenement(int id, Evenement evenement)
        {
            if(id != evenement.Id)
            {
                return BadRequest();
            }
            _evenementRepository.Update(evenement);
            _evenementRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Evenement> DeleteEvenement(int id)
        {
            Evenement evenement = _evenementRepository.GetById(id);
            if(evenement == null)
            {
                return NotFound();
            }
            _evenementRepository.Delete(evenement);
            _evenementRepository.SaveChanges();
            return evenement;
        }



        
    }
}