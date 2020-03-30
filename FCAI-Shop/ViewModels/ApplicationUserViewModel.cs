using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;

namespace FCAI_Shop.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Name { get; }
        public string Password { get; }
        public string Email { get; }
        public string UserName { get; }

        public ApplicationUserViewModel(ApplicationUser user)
        {
            Name = user.Name;
            Password = user.Password;
            Email = user.Email;
            UserName = user.UserName;
        }
    }
}