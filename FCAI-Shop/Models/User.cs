using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using FCAI_Shop.Constants;
using FCAI_Shop.DbContext;
namespace FCAI_Shop.Models
{
    [Table("User")]
    public class User : ApplicationUser
    {
        private User() : base("", "", "", "", "")
        {

        }
        public User(string name, string password, string email, string username) : base(name, password, email, username,Roles.User)
        {
        }
    }
}