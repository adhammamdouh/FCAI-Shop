using FCAI_Shop.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FCAI_Shop.Models
{
    public class ShopDbContext : DbContext
    {
        // Doesn't work on my server
        private const string connectionString =
            "Server=tcp:web-api.database.windows.net,1433;Initial Catalog=FCAI-Shop-Core;Persist Security Info=False;User ID=belal;Password=FCAI-shop1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //"Server=.\\SQLEXPRESS;Database=FCAI-TEST;Integrated Security=True;MultipleActiveResultSets=True;"
        //"Server=localhost;Initial Catalog=FCAI;Integrated Security=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ShopOwner> ShopOwners { get; set; }

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties();
                if (properties == null || !properties.Any()) continue;

                foreach (var property in properties)
                {

                    if (UniqueKeyAttribute.IsUniqueKeyAttribute(entityType, property))
                    {
                        entityType.AddKey(property);
                    }
                }
            }
        }
    }
}
