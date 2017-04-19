﻿using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Data
{
    public class RestaurantAppData
    {
        //private RestaurantData_EF _restaurantdata_EF;
        private UserData _userData;
        private RestaurantData _restaurantData;

        public RestaurantAppData(RestaurantAppContext context)
        {
            //_restaurantdata_EF = new RestaurantData_EF(context);
            _userData = new UserData(context);
        }

        public RestaurantAppData(IDriver driver)
        {
            _restaurantData = new RestaurantData(driver);
        }

        public RestaurantData Restaurant
        {
            get
            {
                return _restaurantData;
            }
        } 

        //public RestaurantData_EF Restaurant_EF
        //{
        //    get
        //    {
        //        return _restaurantdata_EF;
        //    }
        //}

        public UserData User
        {
            get
            {
                return _userData;
            }
        }
    }
}
