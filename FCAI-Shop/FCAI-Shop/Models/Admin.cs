using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FCAI_Shop.Constants;

namespace FCAI_Shop.Models
{
    [Table("Admin")]
    public class Admin : ApplicationUser
    {
        public Admin(string name, string password, string email, string username) : base(name, password, email, username,Roles.Admin)
        {
        }
    }
}