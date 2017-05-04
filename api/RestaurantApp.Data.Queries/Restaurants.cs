using System;

namespace RestaurantApp.Data.Queries
{
    public class Restaurants
    {
        public const string GET_ALL = "MATCH (r:Restaurant) RETURN r.uuid as Id, r.name as Name, r.description as Description, r.takeout as TakeOut";

        public const string GET_BY_ID = "MATCH(r:Restaurant {uuid: {uuid}}) RETURN r.uuid as Id, r.name as Name, r.description as Description, r.takeout as TakeOut";

        public const string CREATE = @"CREATE (r:Restaurant {uuid: {uuid}, name: {name}, description: {description}, takeout: {takeout}})";

        public const string UPDATE = @"MATCH (r:Restaurant {uuid: {uuid}}) SET r.name = {name}, r.description = {description}, r.takeout = {takeout}";

        public const string DELETE = @"MATCH (r:Restaurant { uuid: {uuid} }) DETACH DELETE r";
    }
}
