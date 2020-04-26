using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FCAI_Shop.Utilities;
using FCAI_Shop.Dtos;

namespace FCAI_Shop.Models
{
    [Table("Admins")]
    public class Admin : ApplicationUser
    {

        public Admin()
        {

        }
        public Admin(AdminDto admin) : base(admin, Constants.Roles.Admin)
        {
        }

        public new AdminDto ToDto()
        {
            return new AdminDto
            { Email = Email, Name = Name, Password = "hidden", UserName = UserName,Role = Role };
        }

    }

}