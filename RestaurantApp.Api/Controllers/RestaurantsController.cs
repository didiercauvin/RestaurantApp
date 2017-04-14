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
        private RestaurantRepository _repo;

        public RestaurantsController(RestaurantRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get all restaurants
        /// </summary>
        /// <returns>List of restaurants</returns>
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _repo.GetRestaurants();
        }

        /// <summary>
        /// Get a restaurant based on an id
        /// </summary>
        /// <param name="id">id of the restaurant</param>
        /// <returns>Instance of Restaurant class</returns>
        [HttpGet("{id}")]
        public Restaurant Get(int id)
        {
            return new Restaurant { Id = 1, Name = "Restaurant 1" };
        }
    }
}