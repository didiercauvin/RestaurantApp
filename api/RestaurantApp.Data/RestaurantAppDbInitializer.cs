using System.Linq;
using RestaurantApp.Domain;

namespace RestaurantApp.Data
{
    public static class RestaurantAppDbInitializer
    {
        public static void Initialize(RestaurantAppIdentityContext identityContext)
        {
            identityContext.Database.EnsureCreated();
            
            var didier = new RestaurantUser { UserName = "Didier" };
            var ludovic = new RestaurantUser { UserName = "Ludovic" };

            var users = new []
            {
                didier,
                ludovic
            };

            identityContext.Users.AddRange(users);

            identityContext.SaveChanges();
        }
    }
}