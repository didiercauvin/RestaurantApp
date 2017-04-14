using RestaurantApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Data
{
    public class RestaurantRepository
    {
        private RestaurantAppContext _context;

        public RestaurantRepository(RestaurantAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _context.Restaurants;
        }
    }
}
