using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Data
{
    public class RestaurantAppData
    {
        private RestaurantRepository _restaurantRepo;

        public RestaurantAppData(RestaurantAppContext context)
        {
            _restaurantRepo = new RestaurantRepository(context);
        }

        public RestaurantRepository Restaurant
        {
            get
            {
                return _restaurantRepo;
            }
        }
    }
}
