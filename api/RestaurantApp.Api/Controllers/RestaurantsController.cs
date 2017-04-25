using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Data;
using RestaurantApp.Domain;
using System;

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

            var added = _data.Restaurant.Add(restaurant);

            return CreatedAtRoute("GetRestaurant", new { id = added.Id }, added);
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(long id, [FromBody] Restaurant restaurantData)
        //{
        //    if (restaurantData == null || restaurantData.Id != id)
        //    {
        //        return BadRequest();
        //    }

        //    var restaurant = _data.Restaurant.Get(id);
        //    if (restaurant == null)
        //    {
        //        return NotFound();
        //    }

        //    restaurant.Name = restaurantData.Name;
        //    restaurant.Address = restaurantData.Address;
        //    restaurant.ZipCode = restaurantData.ZipCode;
        //    restaurant.City = restaurantData.City;
        //    restaurant.Description = restaurantData.Description;

        //    _data.Restaurant.Update(restaurant);
        //    return new NoContentResult();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(long id)
        //{
        //    var restaurant = _data.Restaurant.Get(id);
        //    if (restaurant == null)
        //    {
        //        return NotFound();
        //    }

        //    _data.Restaurant.Delete(id);

        //    return new NoContentResult();
        //}
    }
}