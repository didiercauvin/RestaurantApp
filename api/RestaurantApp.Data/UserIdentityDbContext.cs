using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Domain;

namespace RestaurantApp.Data 
{
    public class UserIdentityDbContext: IdentityDbContext
    {
        public UserIdentityDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RestaurantUser> Users { get; set; }
    }
}