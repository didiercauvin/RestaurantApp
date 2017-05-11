namespace RestaurantApp.Data.Queries
{
    public class Groups
    {
        public static string GET_BY_ID = "MATCH (g:Group {uuid: {uuid}}) RETURN g.uuid as Id, g.name as Name";
        public static string CREATE = "CREATE (g:Group {uuid: {uuid}, name: {name}})";
        public static string GET_ALL = "MATCH(g:Group) RETURN g.uuid as Id, g.name as Name";
    }
}