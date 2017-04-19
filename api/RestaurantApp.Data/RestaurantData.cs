using Neo4j.Driver.V1;
using RestaurantApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data
{
    public class RestaurantData
    {
        private IDriver _driver;

        public RestaurantData(IDriver driver)
        {
            _driver = driver;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            using (var session = _driver.Session())
            {
                using (var tx = session.BeginTransaction())
                {
                    var result = tx.Run("CREATE (restaurant:Restaurant {name: {name}, Description: {description}, Address: {address}, ZipCode: {zipcode}, City: {city}}) return ID(restaurant)",
                        new Dictionary<string, object> { { "name", restaurant.Name }, { "description", restaurant.Description }, { "address", restaurant.Address }, { "zipcode", restaurant.ZipCode }, { "city", restaurant.City } });
                    tx.Success();

                    return new Restaurant
                    {
                        Id = result.First()[0].As<long>(),
                        Name = restaurant.Name,
                        Address = restaurant.Address,
                        ZipCode = restaurant.ZipCode,
                        City = restaurant.City,
                        Description = restaurant.Description
                    };
                    
                }
            }
        }

        public Restaurant Get(long id)
        {
            using (var session = _driver.Session())
            {
                var restaurant = session.Run("MATCH (n:Restaurant) where ID(n) = {id} RETURN ID(n) as Id, n.name as Name, n.Address as Address, n.ZipCode as ZipCode, n.City as City, n.Description as Description", new Dictionary<string, object> { { "id", id } })
                    .FirstOrDefault();

                if (restaurant != null)
                {
                    return new Restaurant { Id = restaurant["Id"].As<int>(), Name = restaurant["Name"].As<string>(), Address = restaurant["Address"].As<string>(), ZipCode = restaurant["ZipCode"].As<string>(), City = restaurant["City"].As<string>(), Description = restaurant["Description"].As<string>() };
                }
            }

            return null;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            using (var session = _driver.Session())
            {
                var result = session.Run("MATCH (n:Restaurant) RETURN ID(n) as Id, n.name as Name, n.Address as Address, n.ZipCode as ZipCode, n.City as City, n.Description as Description")
                    .Select(x => new Restaurant { Id = x["Id"].As<int>(), Name = x["Name"].As<string>(), Address = x["Address"].As<string>(), ZipCode = x["ZipCode"].As<string>(), City = x["City"].As<string>(), Description = x["Description"].As<string>() });

                return result;
            }
        }
    }
}
