﻿using FCAI_Shop.Dtos;
using FCAI_Shop.Utilities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCAI_Shop.Models
{
    [Table("ShopOwners")]
    public class ShopOwner : ApplicationUser
    {


        public ShopOwner()
        {

        }
        public ShopOwner(ApplicationUserDto user) : base(user, Constants.Roles.ShopOwner)
        {

        }
        public ShopOwner(ShopOwnerDto shopOwner) : base(shopOwner, Constants.Roles.ShopOwner)
        {
        }

        public new ShopOwnerDto ToDto()
        {
            return new ShopOwnerDto
            { Email = Email, Name = Name, Password = "hidden", UserName = UserName, Role = Role };
        }

    }

}