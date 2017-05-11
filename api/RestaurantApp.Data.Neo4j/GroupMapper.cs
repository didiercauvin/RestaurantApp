using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;
using RestaurantApp.Domain;

namespace RestaurantApp.Data.Neo4j
{
    public class GroupMapper
    {
        public AppGroup Map(IRecord group)
        {
            if (group != null)
            {
                return new AppGroup
                {
                    Id = Guid.Parse(group["Id"].As<string>()),
                    Name = group["Name"].As<string>()
                };
            }

            return null;
        }
    }
}
