using System;
using System.Collections.Generic;
using System.Linq;
using FCAI_Shop._Utilities;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbAccess
{
    // To validate user and returns user data
    public static class ApplicationUserRepository
    {
        public static ApplicationUser ValidateUser(string username, string password)
        {
            var user = GetUserByUsername(username) ?? GetUserByEmail(username);
            if (user == default) return default;
            return user.Password.Equals(password) ? user : default;
        }

        public static IEnumerable<ApplicationUserDto> GetAllApplicationUsers()
        {
            using var context = new DatabaseManager().Create();
            return context.ApplicationUsers.ToList().Select(applicationUser => applicationUser.ToDto());
        }

        public static ApplicationUser GetUserByEmail(string email)
        {
            using var context = new DatabaseManager().Create();
            return context.ApplicationUsers.FirstOrDefault(user =>
                user.Email.Equals(email));
        }

        public static ApplicationUser GetUserByUsername(string username)
        {
            using var context = new DatabaseManager().Create();
            return context.ApplicationUsers.FirstOrDefault(user =>
                user.UserName.Equals(username));
        }

    }
}