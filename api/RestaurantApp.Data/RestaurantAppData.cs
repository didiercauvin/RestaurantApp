using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Data
{
    public class RestaurantAppData
    {
        private UserData _userData;
        private RestaurantData _restaurantData;


        public RestaurantAppData(IDriver driver)
        {
            _restaurantData = new RestaurantData(driver);
        }

        public RestaurantData Restaurant => _restaurantData;


        public UserData User => _userData;
    }
}
