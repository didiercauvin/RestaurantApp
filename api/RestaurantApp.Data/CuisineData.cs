using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;
using RestaurantApp.Domain;

namespace RestaurantApp.Data
{
    public class CuisineData
    {
        private IDriver _driver;
        
        public CuisineData(IDriver driver)
        {
            _driver = driver;
        }

        public IEnumerable<Cuisine> GetAll()
        {
            using (_driver)
            {
                using (var session = _driver.Session())
                {
                    var result = session.Run("MATCH (n:CUISINE) RETURN n.id as Id, n.name as Name")
                        .Select(x => new Cuisine { Id = x["Id"].As<int>(), Name = x["Name"].As<string>()});

                    return result;
                }
            }
        }

    }
}
