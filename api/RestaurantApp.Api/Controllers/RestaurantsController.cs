using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Data.Neo4j;
using RestaurantApp.Domain;
using System;
using Neo4j.Driver.V1;

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

        public RestaurantsController(IDriver driver)
        {
            _data = new  RestaurantAppData(driver);
        }

        public IEnumerable<Restaurant> Get()
        {
            return _data.Restaurant.GetAll();
        }

        [HttpGet("{id}", Name = "GetRestaurant")]
        public IActionResult Get(Guid id)
        {
            var restaurant = _data.Restaurant.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Restaurant restaurant)
        {
            if (restaurant == null)
            {
                return BadRequest();
            }

            restaurant = _data.Restaurant.Add(restaurant);

            return CreatedAtRoute("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Restaurant restaurantData)
        {
            if (restaurantData == null || restaurantData.Id != id)
            {
                return BadRequest();
            }

            var restaurant = _data.Restaurant.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            restaurant.Name = restaurantData.Name;
            restaurant.Description = restaurantData.Description;
            restaurant.TakeOut = restaurantData.TakeOut;

            _data.Restaurant.Update(restaurant);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var restaurant = _data.Restaurant.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _data.Restaurant.Delete(id);

            return new NoContentResult();
        }
    }
}