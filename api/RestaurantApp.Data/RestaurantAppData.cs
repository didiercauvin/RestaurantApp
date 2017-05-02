using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Data
{
    public class RestaurantAppData
    {
        public RestaurantAppData(RestaurantAppContext context)
        {
            Restaurant = new RestaurantData(context);
        }

        public RestaurantData Restaurant { get; }


        public UserData User { get; }
    }
}
