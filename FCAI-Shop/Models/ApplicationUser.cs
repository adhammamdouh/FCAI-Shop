using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FCAI_Shop.ViewModels;

namespace FCAI_Shop.Models
{
    public abstract class ApplicationUser
    {
        [Key, Column(Order = 0),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, Index(IsUnique = true), StringLength(Constants.Numbers.DefaultStringLength)]
        public string Email { get; set; }

        [Required, Index(IsUnique = true), StringLength(Constants.Numbers.DefaultStringLength)]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, StringLength(Constants.Numbers.DefaultStringLength)]
        public string Password { get; set; }

        [StringLength(Constants.Numbers.DefaultStringLength)]
        public string UserRoles { get; set; }

        protected ApplicationUser(string name, string password, string email, string userName,string userRoles)
        {
            Name = name;
            Password = password;
            Email = email;
            UserName = userName;
            UserRoles = userRoles;
        }
        public ApplicationUserViewModel ToViewModel()
        {
            return new ApplicationUserViewModel { Email = this.Email, Name = this.Name, UserName = this.UserName, Role = this.UserRoles };
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