using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;
using Microsoft.Ajax.Utilities;

namespace FCAI_Shop.DbContext
{
    // To validate user and returns user data
    public  class ApplicationUserRepository
    {
        // username maybe email or username
        //private static ApplicationUser user; // for class diagram only
        //private DatabaseManager DbContext = new DatabaseManager(); // for class diagram only
        public static ApplicationUser ValidateUser(string username, string password)
        {
            using (var context = new DatabaseManager().Create())
            {

                var loginByEmail= context.ApplicationUsers.FirstOrDefault(user =>
                    user.Email.Equals(username, StringComparison.OrdinalIgnoreCase)
                    && user.Password == password);

                if (loginByEmail == default) return context.ApplicationUsers.FirstOrDefault(user =>
                    user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                    && user.Password == password);

                return loginByEmail;
            }

        }
        public static IEnumerable<ApplicationUserDto> GetAllApplicationUsers()
        {
            using (var context = new DatabaseManager().Create())
            {
                return context.ApplicationUsers.ToList().Select(applicationUser => applicationUser.ToDto());
            }
        }
    }
}