using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantApp.Domain;

namespace RestaurantApp.Data 
{
    public class RestaurantAppIdentityContext: IdentityDbContext
    {
        private readonly IConfigurationRoot _config;

        public RestaurantAppIdentityContext(DbContextOptions options, IConfigurationRoot config) : base(options)
        {
            _config = config;
        }

        public DbSet<RestaurantUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql(_config["ConnectionStrings:RestaurantAppDatabase"], b => b.MigrationsAssembly("RestaurantApp.Api"));
        }
    }
}