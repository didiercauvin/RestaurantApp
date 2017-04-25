using System;

namespace RestaurantApp.Data.Queries
{
    public class Restaurants
    {
        public const string GET_ALL = "MATCH (r:RESTAURANT)-[l:LOCATED_IN]->(s:STREET)-[:STREET_OF]->(c:CITY) RETURN r.uuid as Id, r.name as RestaurantName, r.Description as RestaurantDescription, l.number as StreetNumber, s.name as Street, c.zipcode as ZipCode, c.name as CityName";

        public const string GET_BY_ID = "MATCH(r:RESTAURANT {uuid: {id}}) -[l: LOCATED_IN]->(s: STREET) -[:STREET_OF]->(c: CITY) RETURN r.uuid as Id, r.name as RestaurantName, r.Description as RestaurantDescription, l.number as StreetNumber, s.name as Street, c.zipcode as ZipCode, c.name as CityName";

        public const string CREATE = @"MERGE (r:RESTAURANT {uuid: {uuid}, name: {name}})
                                       MERGE(s:STREET { name: {street}})
                                       MERGE(c:CITY { name: {city}, zipcode: {zipcode}})
                                       MERGE(s)-[:STREET_OF]->(c)
                                       MERGE(r)-[:LOCATED_IN {number: {streetNumber}}]->(s)";
    }
}
