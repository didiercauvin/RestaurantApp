using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantApp.Domain;

namespace Neo4jCypherQueries
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cypher = new CypherQuery();
            Restaurant[] restaurants = cypher.Get<Restaurant>().Run();
        }
    }

    public class CypherQuery
    {
        public CypherQuery Get<T>()
        {
            return this;
        }

        public void Run()
        {
            
        }
    }
}
