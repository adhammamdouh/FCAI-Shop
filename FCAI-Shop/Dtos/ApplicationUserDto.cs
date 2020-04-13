using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;
#pragma warning disable 1591

namespace FCAI_Shop.Dtos
{
    public class ApplicationUserDto
    {
        //private ApplicationUser ApplicationUser; // for class diagram only

        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}