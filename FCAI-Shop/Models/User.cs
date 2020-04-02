﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using FCAI_Shop.Constants;
using FCAI_Shop.DbContext;
using FCAI_Shop.Dtos;
#pragma warning disable 1591

namespace FCAI_Shop.Models
{
    [Table("Users")]
    public class User : ApplicationUser
    {
        private User()
        {

        }
        public User(UserDto user) : base(user, Roles.User)
        {
        }
        public new UserDto ToDto()
        {
            return new UserDto
            { Email = Email, Name = Name, Password = "".PadRight(Password.Length, '*'), UserName = UserName };
        }

    }
}