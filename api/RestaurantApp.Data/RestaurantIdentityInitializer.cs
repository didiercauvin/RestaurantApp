using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RestaurantApp.Domain;
using System.Security.Claims;

namespace RestaurantApp.Data
{
    public class RestaurantIdentityInitializer
    {
        private readonly UserManager<RestaurantUser> _userMgr;
        private readonly RoleManager<IdentityRole> _roleMgr;

        public RestaurantIdentityInitializer(UserManager<RestaurantUser> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            _userMgr = userMgr;
            _roleMgr = roleMgr;
        }

        public async Task Seed()
        {
            var user = await _userMgr.FindByNameAsync("didier");

            if (user == null)
            {
                if (!await _roleMgr.RoleExistsAsync("Admin"))
                {
                    var role = new IdentityRole("Admin");
                    role.Claims.Add(new IdentityRoleClaim<string>{ClaimType = "IsAdmin", ClaimValue = "True"});
                    await _roleMgr.CreateAsync(role);
                }

                user = new RestaurantUser
                {
                    UserName = "didiercauvin",
                    Name = "didier",
                    Email = "didier.cauvin@gmail.com"
                };

                var userResult = await _userMgr.CreateAsync(user, "P@ssw0rd!");
                var roleResult = await _userMgr.AddToRoleAsync(user, "Admin");
                var claimResult = await _userMgr.AddClaimAsync(user, new Claim("SuperUser", "True"));

                if (!userResult.Succeeded || !roleResult.Succeeded || !claimResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }
        }
    }
}