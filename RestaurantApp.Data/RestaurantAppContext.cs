using Microsoft.EntityFrameworkCore;

namespace RestaurantApp.Data 
{
    public class RestaurantAppContext: DbContext
    {
        public RestaurantAppContext(DbContextOptions<RestaurantAppContext> options): base(options)
        {
            
        }
    }
}