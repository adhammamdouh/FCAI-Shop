using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.DbContext;

namespace FCAI_Shop.Models
{
    public static class UserManager
    {

        public static ApplicationDbContext context = Database.context;
        public static User FindUserById(int Id)
        {
            return context.Users.SingleOrDefault(user => user.Id == Id);
        }

        public static User FindUserByEmail(String Email)
        {
            return context.Users.FirstOrDefault(user => user.Email.Equals(Email));
        }
        public static User FindUserByUserName(String UserName)
        {
            return context.Users.SingleOrDefault(user => user.Username == UserName);
        }
        public static User AddUser(User user)
        {
            if (FindUserByEmail(user.Email) != null || FindUserByUserName(user.Username) != null)
                return null;

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }
        public static IEnumerable<User> GetAllUsers()
        {
            return Database.context.Users.ToList();
        }
    }
}