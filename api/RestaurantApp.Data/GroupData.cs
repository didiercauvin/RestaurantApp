using System;
using System.Collections.Generic;
using System.Linq;
using Neo4j.Driver.V1;
using RestaurantApp.Data.Queries;
using RestaurantApp.Domain;

namespace RestaurantApp.Data
{
    public class GroupData
    {
        private readonly IDriver _driver;
        private GroupMapper _groupMapper;

        public GroupData(IDriver driver)
        {
            _driver = driver;
            _groupMapper = new GroupMapper();
        }

        public Group Add(Group group)
        {
            if (group != null)
            {
                using (var session = _driver.Session())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        var guid = Guid.NewGuid();
                        tx.Run(Groups.CREATE,
                            new Dictionary<string, object>
                            {
                                {"uuid", guid.ToString()},
                                {"name", group.Name}
                            });

                        tx.Success();

                        return new Group
                        {
                            Id = guid,
                            Name = group.Name
                        };

                    }
                }
            }

            return null;
        }

        public Group Get(Guid id)
        {
            using (var session = _driver.Session())
            {
                var group = session.Run(Groups.GET_BY_ID, new Dictionary<string, object> {{"uuid", id.ToString()}})
                    .FirstOrDefault();

                return _groupMapper.Map(group);
            }
        }

        public IEnumerable<Group> GetAll()
        {
            using (var session = _driver.Session())
            {
                return session.Run(Groups.GET_ALL).Select(_groupMapper.Map);
            }
        }
    }
}
