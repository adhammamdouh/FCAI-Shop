using FCAI_Shop.Dtos;
using FCAI_Shop.Models;
using FCAI_Shop.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace FCAI_Shop.DbAccess
{
    // To validate user and returns user data
    public static class ApplicationUserManager
    {
        public static ApplicationUser ValidateUser(string username, string password)
        {
            var user = GetUserByUsername(username) ?? GetUserByEmail(username);
            if (user == default) return default;

            return Procedures.CompareHashedPassword(password, user.Password) ? user : default;
        }

        public static IEnumerable<ApplicationUserDto> GetAllApplicationUsers()
        {
            using var context = new ShopDbContext();
            return context.ApplicationUsers.ToList().Select(applicationUser => applicationUser.ToDto());
        }

        public static bool UserExists(int id)
        {
            using var context = new ShopDbContext();
            return context.ApplicationUsers.ToList().FirstOrDefault(ApplicationUser => ApplicationUser.Id == id) != default;
        }

        public static ApplicationUser GetUserByEmail(string email)
        {
            using var context = new ShopDbContext();
            return context.ApplicationUsers.FirstOrDefault(user =>
                user.Email.Equals(email));
        }

        public static ApplicationUser GetUserByUsername(string username)
        {
            using var context = new ShopDbContext();
            return context.ApplicationUsers.FirstOrDefault(user =>
                user.UserName.Equals(username));
        }

    }
}