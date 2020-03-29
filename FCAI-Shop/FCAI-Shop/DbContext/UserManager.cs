using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.DbContext;

namespace FCAI_Shop.Models
{
    public static class UserManager
    {

        private static readonly ApplicationDbContext Context = DatabaseManager.Context;
        public static User FindUserById(int id)
        {
            return Context.Users.FirstOrDefault(user => user.Id == id);
        }

        public static User FindUserByEmail(string email)
        {
            return Context.Users.FirstOrDefault(user => user.Email.Equals(email));
        }
        public static User FindUserByUserName(string userName)
        {
            return Context.Users.FirstOrDefault(user => user.UserName.Equals(userName));
        }
        public static int? AddUser(User user)
        {
           /* if (FindUserByEmail(user.Email) != null || FindUserByUserName(user.UserName) != null)
                return null;*/

            Context.Users.Add(user);

            if(Context.SaveChanges() == 0)
                return null;

            return user.Id;
        }
        public static IEnumerable<User> GetAllUsers()
        {
            return Context.Users.ToList();
        }
    }
}