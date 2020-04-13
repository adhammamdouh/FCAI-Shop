using System.Data.Entity;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbContext
{
    public class ShopDbContext : System.Data.Entity.DbContext
    {
        private const string AzureDatabase =
            "Server=tcp:web-api.database.windows.net,1433;Initial Catalog=FCAI-Shop;Persist Security Info=False;User ID=belal;Password=FCAI-shop1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //private const string LocalDatabase = "FCAI_Shop"; // (LocalDb)\MSSQLLocalDB
        public ShopDbContext() : base(AzureDatabase)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ShopDbContext>());
        }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShopOwner> ShopOwners { get; set; }

    }
}