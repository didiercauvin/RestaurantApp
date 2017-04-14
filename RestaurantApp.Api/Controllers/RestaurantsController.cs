using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Data;
using RestaurantApp.Domain;

namespace RestaurantApp.Api.Controllers
{
    /// <summary>
    /// Restaurants controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/restaurants")]
    public class RestaurantsController : Controller
    {
        private RestaurantAppData _data;

        public RestaurantsController(RestaurantAppData data)
        {
            _data = data;
        }

        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _data.Restaurant.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var restaurant = _data.Restaurant.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }
    }
}