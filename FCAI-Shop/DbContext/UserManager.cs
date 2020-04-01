using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Constants;
using FCAI_Shop.DbContext;
using FCAI_Shop.Dtos;

namespace FCAI_Shop.Models
{
    public class UserManager
    {
        //private static User user; // for class diagram only
        //private static DatabaseManager DbContext = new DatabaseManager(); // for class diagram only
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
        public static int? AddUser(UserDto user)
        {
            /* if (FindUserByEmail(user.Email) != null || FindUserByUserName(user.UserName) != null)
                 return null;*/
            
            using (var context = new DatabaseManager().Create())
            {
                var addedUser = context.Users.Add(new User(user));

                if (context.SaveChanges() == 0)
                    return null;

                return addedUser.Id;
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