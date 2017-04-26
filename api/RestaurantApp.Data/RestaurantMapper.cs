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
                    Name = restaurant["Name"].As<string>(),
                    Address = restaurant["Address"].As<string>(),
                    ZipCode = restaurant["ZipCode"].As<string>(),
                    City = restaurant["CityName"].As<string>(),
                    Description = restaurant["Description"].As<string>(),
                    TakeOut = restaurant["TakeOut"].As<string>()
                };
            }

            return null;
        }
    }
}
