using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.DbContext;

namespace FCAI_Shop.Models
{
    public static class UserManager
    {

        public static User FindUserById(int id)
        {
            using (var context = new DatabaseManager().Create())
            {
                return context.Users.FirstOrDefault(user => user.Id == id);
            }
        }

        public static User FindUserByEmail(string email)
        {
            using (var context = new DatabaseManager().Create())
            {
                return context.Users.FirstOrDefault(user => user.Email.Equals(email));
            }
        }
        public static User FindUserByUserName(string userName)
        {
            using (var context = new DatabaseManager().Create())
            {
                return context.Users.FirstOrDefault(user => user.UserName.Equals(userName));
            }
        }
        public static int? AddUser(User user)
        {
           /* if (FindUserByEmail(user.Email) != null || FindUserByUserName(user.UserName) != null)
                return null;*/
           using (var context = new DatabaseManager().Create())
           {
               context.Users.Add(user);

               if (context.SaveChanges() == 0)
                   return null;

               return user.Id;
           }
        }
        public static IEnumerable<User> GetAllUsers()
        {
            using (var context = new DatabaseManager().Create())
            {
                return context.Users.ToList();
            }
        }
    }
}