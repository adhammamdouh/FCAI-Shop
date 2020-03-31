using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FCAI_Shop.Constants;
using FCAI_Shop.ViewModels;

namespace FCAI_Shop.Models
{
    [Table("Admin")]
    public class Admin : ApplicationUser
    {
        private Admin() : base("", "", "", "", "")
        {

        }
        public Admin(string name, string password, string email, string username) : base(name, password, email, username,Roles.Admin)
        {
        }
        public AdminViewModel ToViewModel()
        {
            return new AdminViewModel { Email = this.Email, Name = this.Name, UserName = this.UserName };
        }
    }
}