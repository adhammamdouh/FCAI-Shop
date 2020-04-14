using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using FCAI_Shop.Utility;
using FCAI_Shop.DbContext;
using FCAI_Shop.Dtos;

namespace FCAI_Shop.Models
{
    [Table("ShopOwners")]
    public class ShopOwner : ApplicationUser
    {
        private ShopOwner()
        {

        }
        public ShopOwner(ApplicationUserDto user) : base(user)
        {

        }
        public ShopOwner(ShopOwnerDto user) : base(user)
        {
        }
        public new ShopOwnerDto ToDto()
        {
            return new ShopOwnerDto
            { Email = Email, Name = Name, Password = "", UserName = UserName, Role = UserRoles };
        }

    }
}