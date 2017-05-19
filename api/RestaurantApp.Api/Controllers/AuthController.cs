using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Api.Models;
using RestaurantApp.Data;
using RestaurantApp.Domain;

namespace RestaurantApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly RestaurantAppContext _context;
        private readonly SignInManager<RestaurantUser> _signInMgr;

        public AuthController(RestaurantAppContext context, SignInManager<RestaurantUser> signInMgr)
        {
            _context = context;
            _signInMgr = signInMgr;
        }

        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CredentialModel credential)
        {
            try
            {
                var result = await _signInMgr.PasswordSignInAsync(credential.Login, credential.Password, false, false);

                if (result.Succeeded)
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {

            }

            return BadRequest("Failed to login");
        }
    }
}