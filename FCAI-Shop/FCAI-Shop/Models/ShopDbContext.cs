using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FCAI_Shop._Utilities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FCAI_Shop.Models
{
    public class ShopDbContext : DbContext
    {
        private const string connectionString =
            //"Server=tcp:web-api.database.windows.net,1433;Initial Catalog=FCAI-Shop;Persist Security Info=False;User ID=belal;Password=FCAI-shop1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            "Server=(localdb)/MSSQLLocalDB;Initial Catalog=FCAI-Shop;Integrated Security=true;";

        //private const string LocalDatabase = "FCAI_Shop"; // (LocalDb)\MSSQLLocalDB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties();
                if (properties == null || properties.Any()) continue;

                foreach (var property in properties)
                {
                    if (UniqueKeyAttribute.IsUniqueKeyAttribute(entityType, property))
                         entityType.AddIndex(property).IsUnique = true;
                }
            }
        }
    }
}
