using Neo4j.Driver.V1;
using RestaurantApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Queries;

namespace RestaurantApp.Data
{
    public class RestaurantData
    {
        private IDriver _driver;
        private RestaurantMapper _restaurantMapper;

        public RestaurantData(IDriver driver)
        {
            _driver = driver;
            _restaurantMapper = new RestaurantMapper();
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
                        tx.Run(Restaurants.CREATE,
                            new Dictionary<string, object>
                            {
                                { "uuid", guid.ToString() },
                                { "name", restaurant.Name },
                                { "description", restaurant.Description },
                                { "streetNumber", restaurant.StreetNumber},
                                { "street", restaurant.Street },
                                { "zipcode", restaurant.ZipCode },
                                { "city", restaurant.City }
                            });
                        
                        tx.Success();

                        return new Restaurant
                        {
                            Id = guid,
                            Name = restaurant.Name,
                            StreetNumber = restaurant.StreetNumber,
                            Street = restaurant.Street,
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
                    var restaurant = session.Run(Restaurants.GET_BY_ID, new Dictionary<string, object> { { "id", id.ToString() } })
                        .FirstOrDefault();

                    return _restaurantMapper.Map(restaurant);
                }
            }
        }

        public IEnumerable<Restaurant> GetAll()
        {
            using (_driver)
            {
                using (var session = _driver.Session())
                {
                    var result = session.Run(Restaurants.GET_ALL)
                        .Select(_restaurantMapper.Map);

                    return result;
                }
            }
        }
    }
}
