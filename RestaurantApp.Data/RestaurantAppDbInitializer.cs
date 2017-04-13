using System.Linq;
using RestaurantApp.Domain;

namespace RestaurantApp.Data
{
    public static class RestaurantAppDbInitializer
    {
        public static void Initialize(RestaurantAppContext context)
        {
            context.Database.EnsureCreated();

            if (context.Restaurants.Any())
            {
                return;
            }

            var resto1 = new Restaurant { Name = "Un bon resto 1", Address = "Adresse 1", ZipCode = "13000", City = "Marseille", Description = "Description 1" };
            var resto2 = new Restaurant { Name = "Un bon resto 2", Address = "Adresse 3", ZipCode = "75000", City = "Paris", Description = "Description 2" };

            var restaurants = new Restaurant[]
            {
                resto1,
                resto2
            };

            context.Restaurants.AddRange(restaurants);

            context.SaveChanges();
        }
    }
}