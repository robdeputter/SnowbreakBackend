using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Snowboard_WEB4.DTO_s;
using Snowboard_WEB4.Model;

namespace Snowboard_WEB4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGebruikerRepository _gebruikerRepository;
        private readonly IConfiguration _config;

        public AccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IGebruikerRepository gebruikerRepository,
            IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _gebruikerRepository = gebruikerRepository;
            _config = config;
        }

        [AllowAnonymous]
        [HttpGet("checkusername")]
        public async Task<ActionResult<Boolean>> CheckAvailableUserName(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return user == null;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Email); if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    string token = GetToken(user);
                    return Created("", token); //returns only the token
                }
            }
            return BadRequest();
        }

        private string GetToken(IdentityUser user)
        {      // Createthetoken
            var claims = new[]       {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(null, null, claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(RegisterDTO model)
        {
            IdentityUser user = new IdentityUser { UserName = model.Email, Email = model.Email };
            Gebruiker gebruiker = new Gebruiker{ Email = model.Email, Voornaam = model.FirstName, Familienaam = model.LastName };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                _gebruikerRepository.Add(gebruiker);
                _gebruikerRepository.SaveChanges();
                string token = GetToken(user);
                return Created("", token);
            }
            return BadRequest();
        }


    }
    
}

