using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;
using Microsoft.Ajax.Utilities;

namespace FCAI_Shop.DbContext
{
    // To validate user and returns user data
    public class ApplicationUserRepository
    {
        // username maybe email or username
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
    }
}