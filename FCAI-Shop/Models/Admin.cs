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
        public Admin(AdminDto admin) : base(admin,Roles.Admin)
        {
        }

        public new AdminDto ToDto()
        {
            AdminDto dt = (AdminDto)base.ToDto();
            return dt;
        }

    }

}