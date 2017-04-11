using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Domain;

namespace RestaurantApp.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/restaurants")]
    public class RestaurantsController : Controller
    {
        public IEnumerable<Restaurant> Get()
        {
            var restaurants = new Restaurant[] 
            {
                new Restaurant { Id = 1, Name = "Restaurant 1" },
                new Restaurant { Id = 2, Name = "Restaurant 2" }
            };
            
            return restaurants;
        }
    }
}