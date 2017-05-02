using System;
using Neo4j.Driver.V1;
using RestaurantApp.Domain;

namespace RestaurantApp.Data.Neo4j
{
    public class RestaurantMapper
    {
        public Restaurant Map(IRecord restaurant)
        {
            if (restaurant != null)
            {
                return new Restaurant
                {
                    Id = restaurant["Id"].As<long>(),
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
