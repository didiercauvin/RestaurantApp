using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Data
{
    public class RestaurantAppData
    {
        private RestaurantData _restaurantdata;
        private UserData _userData;

        public RestaurantAppData(RestaurantAppContext context)
        {
            _restaurantdata = new RestaurantData(context);
            _userData = new UserData(context);
        }

        public RestaurantData Restaurant
        {
            get
            {
                return _restaurantdata;
            }
        }

        public UserData User
        {
            get
            {
                return _userData;
            }
        }
    }
}
