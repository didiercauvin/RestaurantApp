using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Data;
using RestaurantApp.Domain;

namespace RestaurantApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private RestaurantAppData _data;

        public UsersController(RestaurantAppData data)
        {
            _data = data;
        }

        public IEnumerable<User> Get()
        {
            return _data.User.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var user = _data.User.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}