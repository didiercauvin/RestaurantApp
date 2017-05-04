using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;

namespace RestaurantApp.Data.Neo4j
{
    public class RestaurantAppData
    {
        public RestaurantAppData(IDriver context)
        {
            Restaurant = new RestaurantData(context);
        }

        public RestaurantData Restaurant { get; }


        //public UserData User { get; }
    }
}
