using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Data
{
    public class UserAppData
    {
        public UserAppData(UserIdentityDbContext context)
        {
            User = new UserData(context);
        }
        
        public UserData User { get; }
    }
}
