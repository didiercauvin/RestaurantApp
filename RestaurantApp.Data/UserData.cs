using RestaurantApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data
{
    public class UserData
    {
        private RestaurantAppContext _context;

        public UserData(RestaurantAppContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User Get(long id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
