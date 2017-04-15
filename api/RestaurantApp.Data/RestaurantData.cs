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

        public Restaurant Get(long id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }
        
        public void Update(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var restaurant = _context.Restaurants.First(x => x.Id == id);
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }
    }
}
