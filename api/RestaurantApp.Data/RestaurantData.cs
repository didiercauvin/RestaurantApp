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
            using (_driver)
            {
                using (var session = _driver.Session())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        var guid = Guid.NewGuid();
                        var result = tx.Run("CREATE (restaurant:RESTAURANT {guid: {guid}, name: {name}, Description: {description}, Address: {address}, ZipCode: {zipcode}, City: {city}})",
                            new Dictionary<string, object> { { "guid", guid.ToString() }, { "name", restaurant.Name }, { "description", restaurant.Description }, { "address", restaurant.Address }, { "zipcode", restaurant.ZipCode }, { "city", restaurant.City } });
                        tx.Success();

                        return new Restaurant
                        {
                            Id = guid,
                            Name = restaurant.Name,
                            Address = restaurant.Address,
                            ZipCode = restaurant.ZipCode,
                            City = restaurant.City,
                            Description = restaurant.Description
                        };

                    }
                }
            }
        }

        public Restaurant Get(Guid id)
        {
            using (_driver)
            {
                using (var session = _driver.Session())
                {
                    var restaurant = session.Run("MATCH (n:RESTAURANT) where n.guid = {id} RETURN n.guid as Id, n.name as Name, n.Address as Address, n.ZipCode as ZipCode, n.City as City, n.Description as Description", new Dictionary<string, object> { { "id", id.ToString() } })
                        .FirstOrDefault();

                    if (restaurant != null)
                    {
                        return new Restaurant { Id = id, Name = restaurant["Name"].As<string>(), Address = restaurant["Address"].As<string>(), ZipCode = restaurant["ZipCode"].As<string>(), City = restaurant["City"].As<string>(), Description = restaurant["Description"].As<string>() };
                    }
                }
            }

            return null;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            using (_driver)
            {
                using (var session = _driver.Session())
                {
                    var result = session.Run("MATCH (n:RESTAURANT) RETURN n.guid as Id, n.name as Name, n.Address as Address, n.ZipCode as ZipCode, n.City as City, n.Description as Description")
                        .Select(x => new Restaurant { Id = Guid.Parse(x["Id"].As<string>()), Name = x["Name"].As<string>(), Address = x["Address"].As<string>(), ZipCode = x["ZipCode"].As<string>(), City = x["City"].As<string>(), Description = x["Description"].As<string>() });

                    return result;
                }
            }
        }
    }
}
