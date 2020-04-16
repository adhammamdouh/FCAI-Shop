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
            "Server=(localdb)/MSSQLLocalDB;Initial Catalog=FCAI;Integrated Security=true;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MYDB;Integrated Security=True;MultipleActiveResultSets=True;");
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<ShopOwner> ShopOwners{ get; set; }

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }

    }
}
