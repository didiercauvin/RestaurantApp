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
        public RestaurantAppData(IDriver driver)
        {
            Restaurant = new RestaurantData(driver);
            Group = new GroupData(driver);
        }

        public RestaurantData Restaurant { get; }

        public GroupData Group { get; set; }
        //public UserData User { get; }
    }
}
