using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Data
{
    public class Neo4jTest
    {
        public object GetData()
        {
            using (var driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "restaurant")))
            using (var session = driver.Session())
            {
                var result = session.Run("match (v)<-[:ADDED_TO]-(r) return distinct r.name as name");

                return result.Select(x => x.Values);
            }
        }
    }
}
