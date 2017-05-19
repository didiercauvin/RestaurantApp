using System.Linq;
using RestaurantApp.Domain;

namespace RestaurantApp.Data
{
    public static class RestaurantAppDbInitializer
    {
        public static void Initialize(RestaurantAppContext context)
        {
            context.Database.EnsureCreated();
            
            var didier = new RestaurantUser { Name = "Didier" };
            var ludovic = new RestaurantUser { Name = "Ludovic" };

            var users = new []
            {
                didier,
                ludovic
            };

            context.Users.AddRange(users);

            context.SaveChanges();
        }
    }
}