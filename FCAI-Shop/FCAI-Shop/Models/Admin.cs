using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FCAI_Shop._Utilities;
using FCAI_Shop.Dtos;

namespace FCAI_Shop.Models
{
    [Table("Admins")]
    public class Admin : ApplicationUser
    {
        private Admin()
        {

        }
        public Admin(AdminDto admin) : base(admin, Constants.Admin)
        {
        }

        public new AdminDto ToDto()
        {
            return new AdminDto
            { Email = Email, Name = Name, Password = "".PadRight(Password.Length, '*'), UserName = UserName };
        }

    }

}