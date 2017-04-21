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
    [Route("api/Cuisines")]
    public class CuisinesController : Controller
    {
        private RestaurantAppData _data;

        public CuisinesController(RestaurantAppData data)
        {
            _data = data;
        }

        public IEnumerable<Cuisine> Get()
        {
            return _data.Cuisine.GetAll();
        }
    }
}