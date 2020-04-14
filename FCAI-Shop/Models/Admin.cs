using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FCAI_Shop.Utility;
using FCAI_Shop.Dtos;
#pragma warning disable 1591


namespace FCAI_Shop.Models
{
    [Table("Admins")]
    public class Admin : ApplicationUser
    {
        private Admin()
        {

        }
        public Admin(AdminDto admin) : base(admin)
        {
        }

        public new AdminDto ToDto()
        {
            return new AdminDto
            { Email = Email, Name = Name, Password = "", UserName = UserName, Role = UserRoles };
        }

    }

}