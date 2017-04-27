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
        private IDriver _driver;

        public UserData(IDriver driver)
        {
            _driver = driver;
        }

        public IEnumerable<User> GetAll()
        {
            //using (var session = _driver.Session())
            //{
            //    var result = session.Run(Users.GET_ALL)
            //        .Select(_restaurantMapper.Map);

            //    return result;
            //}

            return null;
        }

        public User Get(long id)
        {
            //return _context.Users.FirstOrDefault(x => x.Id == id);
            return null;
        }
    }
}
