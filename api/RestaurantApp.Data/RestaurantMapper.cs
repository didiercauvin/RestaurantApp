using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;
using RestaurantApp.Domain;

namespace RestaurantApp.Data
{
    public class RestaurantMapper
    {
        public Restaurant Map(IRecord restaurant)
        {
            if (restaurant != null)
            {
                return new Restaurant
                {
                    Id = Guid.Parse(restaurant["Id"].As<string>()),
                    Name = restaurant["RestaurantName"].As<string>(),
                    StreetNumber = restaurant["StreetNumber"].As<string>(),
                    Street = restaurant["Street"].As<string>(),
                    ZipCode = restaurant["ZipCode"].As<string>(),
                    City = restaurant["CityName"].As<string>(),
                    Description = restaurant["RestaurantDescription"].As<string>()
                };
            }

            return null;
        }
    }
}
