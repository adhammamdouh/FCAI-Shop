﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using FCAI_Shop.Dtos;
#pragma warning disable 1591


namespace FCAI_Shop.Models
{
    public abstract class ApplicationUser
    {
        [Key, Column(Order = 0),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required, Index(IsUnique = true), StringLength(Constants.Numbers.DefaultStringLength),DataType(DataType.EmailAddress),EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Name { get; set; }


        [Required, Index(IsUnique = true), StringLength(Constants.Numbers.DefaultStringLength)]
        public string UserName { get; set; }



        [Required, StringLength(Constants.Numbers.DefaultStringLength)]
        public string Password { get; set; }


        [StringLength(Constants.Numbers.DefaultStringLength)]
        public string UserRoles { get; set; }

        protected ApplicationUser(ApplicationUserDto applicationUser,string userRoles)
        {
            Name = applicationUser.Name;
            Password = applicationUser.Password;
            Email = applicationUser.Email;
            UserName = applicationUser.UserName;
            UserRoles = userRoles;
        }

        protected ApplicationUser()
        {

        }
        public ApplicationUserDto ToDto()
        {
            return new ApplicationUserDto
                { Email = Email, Name = Name, Password = "".PadRight(Password.Length, '*'), UserName = UserName };
        }
    }
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        private const string AzureDatabase =
            "Server=tcp:web-api.database.windows.net,1433;Initial Catalog=FCAI-Shop;Persist Security Info=False;User ID=belal;Password=FCAI-shop1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private const string LocalDatabase = "FCAI_Shop"; // (LocalDb)\MSSQLLocalDB
        public ApplicationDbContext() : base(AzureDatabase)
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