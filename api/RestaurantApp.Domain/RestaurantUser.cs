using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RestaurantApp.Domain
{
    public class RestaurantUser: IdentityUser<Guid>
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
    }
}
