using RestaurantApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;

namespace RestaurantApp.Data
{
    public class UserData
    {
        private UserIdentityDbContext _context;

        public UserData(UserIdentityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RestaurantUser> GetAll()
        {
            //using (var session = _driver.Session())
            //{
            //    var result = session.Run(Users.GET_ALL)
            //        .Select(_restaurantMapper.Map);

            //    return result;
            //}

            return null;
        }

        public RestaurantUser Get(long id)
        {
            //return _context.Users.FirstOrDefault(x => x.Id == id);
            return null;
        }
    }
}
