using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FCAI_Shop.Models
{
    public abstract class ApplicationUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        protected ApplicationUser(string name, string password, string email, string username)
        {
            Name = name;
            Password = password;
            Email = email;
            Username = username;
        }
    }
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        public ApplicationDbContext() : base("FCAI_Shop")
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<User> Users { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}