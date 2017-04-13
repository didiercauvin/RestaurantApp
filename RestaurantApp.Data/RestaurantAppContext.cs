using Microsoft.EntityFrameworkCore;
using RestaurantApp.Domain;

namespace RestaurantApp.Data 
{
    public class RestaurantAppContext: DbContext
    {
        public RestaurantAppContext(DbContextOptions<RestaurantAppContext> options): base(options)
        {
            
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}