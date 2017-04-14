using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Data
{
    public class RestaurantAppData
    {
        private RestaurantData _restaurantRepo;

        public RestaurantAppData(RestaurantAppContext context)
        {
            _restaurantRepo = new RestaurantData(context);
        }

        public RestaurantData Restaurant
        {
            get
            {
                return _restaurantRepo;
            }
        }
    }
}
