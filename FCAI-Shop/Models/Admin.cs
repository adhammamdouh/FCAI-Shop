using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FCAI_Shop.Constants;
using FCAI_Shop.Dtos;


namespace FCAI_Shop.Models
{
    [Table("Admins")]
    public class Admin : ApplicationUser
    {
        private Admin()
        {

        }
        public Admin(AdminDto admin) : base(admin,Roles.Admin)
        {
        }

        public new AdminDto ToDto()
        {
            return new AdminDto
                {Email = this.Email, Name = this.Name, Password = this.Password, UserName = this.UserName};
        }

    }

}