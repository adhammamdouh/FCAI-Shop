using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;
using FCAI_Shop.ViewModels;

namespace FCAI_Shop.ModelViews
{
    public class UsersViewModel : ApplicationUserViewModel
    {
        UsersViewModel(User user) : base(user)
        {
            
        }
    }
}