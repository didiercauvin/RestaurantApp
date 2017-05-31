using System;
using Neo4j.Driver.V1;
using RestaurantApp.Domain;

namespace RestaurantApp.Data
{
    public class GroupMapper
    {
        public Group Map(IRecord group)
        {
            if (group != null)
            {
                return new Group
                {
                    Id = Guid.Parse(group["Id"].As<string>()),
                    Name = group["Name"].As<string>()
                };
            }

            return null;
        }
    }
}
