using RestaurantApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RestaurantApp.Data
{
    public class RestaurantData
    {
        private RestaurantAppContext _context;

        public RestaurantData(RestaurantAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);
        }
    }
}
