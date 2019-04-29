using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snowboard_WEB4.Model;

namespace Snowboard_WEB4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        [HttpGet]
        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikerRepository.GetAll();
        }

        [HttpGet("{email}")]
        public ActionResult<Gebruiker> GetGebruiker(string email)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetByEmail(email);
            if(gebruiker == null)
            {
                return NotFound();
            }
            return gebruiker;
        }

        [HttpDelete("{email}")]
        public ActionResult<Gebruiker> DeleteGebruiker(string email)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetByEmail(email);
            if(gebruiker == null)
            {
                return NotFound();
            }
            _gebruikerRepository.Delete(gebruiker);
            _gebruikerRepository.SaveChanges();

            return gebruiker;
        }
    }
}