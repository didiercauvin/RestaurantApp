using System;
using System.Collections.Generic;
using System.Linq;
using Neo4j.Driver.V1;
using RestaurantApp.Data.Queries;
using RestaurantApp.Domain;

namespace RestaurantApp.Data.Neo4j
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
            if (restaurant != null)
            {
                using (var session = _driver.Session())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        var guid = Guid.NewGuid();
                        tx.Run(Restaurants.CREATE,
                            new Dictionary<string, object>
                            {
                                {"uuid", guid.ToString()},
                                {"name", restaurant.Name},
                                {"description", restaurant.Description},
                                {"takeout", restaurant.TakeOut}
                            });

                        tx.Success();

                        return new Restaurant
                        {
                            Id = guid,
                            Name = restaurant.Name,
                            Description = restaurant.Description,
                            TakeOut = restaurant.TakeOut
                        };

                    }
                }
            }

            return null;
        }

        public void Update(Restaurant restaurant)
        {
            if (restaurant != null)
            {
                using (var session = _driver.Session())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        tx.Run(Restaurants.UPDATE,
                            new Dictionary<string, object>
                            {
                                {"uuid", restaurant.Id.ToString() },
                                {"name", restaurant.Name},
                                {"description", restaurant.Description},
                                {"takeout", restaurant.TakeOut}
                            });

                        tx.Success();
                    }
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var session = _driver.Session())
            {
                using (var tx = session.BeginTransaction())
                {
                    tx.Run(Restaurants.DELETE, new Dictionary<string, object>
                    {
                        { "uuid", id.ToString()}
                    });

                    tx.Success();
                }
            }
        }

        public Restaurant Get(Guid id)
        {
            using (var session = _driver.Session())
            {
                var restaurant = session.Run(Restaurants.GET_BY_ID, new Dictionary<string, object> { { "uuid", id.ToString() } })
                    .FirstOrDefault();

                return _restaurantMapper.Map(restaurant);
            }
        }

        public IEnumerable<Restaurant> GetAll()
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
