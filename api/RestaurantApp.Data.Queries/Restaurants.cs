using System;

namespace RestaurantApp.Data.Queries
{
    public class Restaurants
    {
        public const string GET_ALL = "MATCH (r:RESTAURANT) RETURN r.uuid as Id, r.name as Name, r.Description as Description, r.address as Address, r.zipcode as ZipCode, r.city as CityName, r.takeout as TakeOut";

        public const string GET_BY_ID = "MATCH(r:RESTAURANT) RETURN r.uuid as Id, r.name as Name, r.Description as Description, r.address as Address, r.zipcode as ZipCode, r.city as CityName, r.takeout as TakeOut";

        public const string CREATE = @"MERGE (r:RESTAURANT {uuid: {uuid}, name: {name}, description: {description}, address: {address}, zipcode: {zipcode}, city: {city}, takeout: {takeout}})";

        public const string UPDATE = @"MERGE (r:RESTAURANT {name: {name}, description: {description}, address: {address}, zipcode: {zipcode}, city: {city}, takeout: {takeout}})";

        public const string DELETE = @"MATCH (n { uuid: {uuid} }) DETACH DELETE n";
    }
}
