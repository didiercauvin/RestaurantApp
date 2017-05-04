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

            var resto1 = new Restaurant { Name = "Un bon resto 1", Description = "Description 1" };
            var resto2 = new Restaurant { Name = "Un bon resto 2", Description = "Description 2" };

            var restaurants = new Restaurant[]
            {
                resto1,
                resto2
            };

            context.Restaurants.AddRange(restaurants);

            var didier = new User { FirstName = "Didier", LastName = "Cauvin" };
            var ludovic = new User { FirstName = "Ludovic", LastName = "Meril" };

            var users = new User[]
            {
                didier,
                ludovic
            };

            context.Users.AddRange(users);

            context.SaveChanges();
        }
    }
}