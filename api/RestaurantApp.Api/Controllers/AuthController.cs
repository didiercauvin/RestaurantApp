using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestaurantApp.Api.Models;
using RestaurantApp.Data;
using RestaurantApp.Domain;

namespace RestaurantApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<RestaurantUser> _userMgr;
        private readonly IPasswordHasher<RestaurantUser> _hasher;
        private readonly IConfigurationRoot _config;

        public AuthController(RestaurantAppIdentityContext identityContext, SignInManager<RestaurantUser> signInMgr, UserManager<RestaurantUser> userMgr, IPasswordHasher<RestaurantUser> hasher, IConfigurationRoot config) 
        {
            _userMgr = userMgr;
            _hasher = hasher;
            _config = config;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CredentialModel model)
        {
            var user = await _userMgr.FindByNameAsync(model.Login);
            if (user != null)
            {
                if (_hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) ==
                    PasswordVerificationResult.Success)
                {
                    var userClaims = await _userMgr.GetClaimsAsync(user);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email) 
                    }.Union(userClaims);

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(issuer: _config["Tokens:Issuer"],
                        audience: _config["Tokens:Audience"], claims: claims, expires: DateTime.UtcNow.AddMinutes(15),
                        signingCredentials: creds);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expriration = token.ValidTo
                    });
                }
            }


            return BadRequest("Failed to login");
        }
    }
}