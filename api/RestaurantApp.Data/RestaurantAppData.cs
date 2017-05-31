using Neo4j.Driver.V1;

namespace RestaurantApp.Data
{
    public class RestaurantAppData
    {
        public RestaurantAppData(IDriver driver)
        {
            Restaurant = new RestaurantData(driver);
            Group = new GroupData(driver);
        }

        public void RegisterDriver()
        {
            
        }

        public RestaurantData Restaurant { get; }

        public GroupData Group { get; set; }
        //public UserData User { get; }
    }
}
