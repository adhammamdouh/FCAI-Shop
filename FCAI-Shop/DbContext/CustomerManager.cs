using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Utility;
using FCAI_Shop.DbContext;
using FCAI_Shop.Dtos;
#pragma warning disable 1591

namespace FCAI_Shop.DbContext
{
    public class CustomerManager
    {
        //private static User user; // for class diagram only
        //private static DatabaseManager DbContext = new DatabaseManager(); // for class diagram only
        public static Customer FindUserById(int id)
        {
            using (var context = new ShopDbContext())
            {
                return context.Customers.FirstOrDefault(user => user.Id == id);
            }
        }

        public static Customer FindUserByEmail(string email)
        {
            using (var context = new ShopDbContext())
            {
                return context.Customers.FirstOrDefault(user => user.Email.Equals(email));
            }
        }
        public static Customer FindUserByUserName(string userName)
        {
            using (var context = new ShopDbContext())
            {
                return context.Customers.FirstOrDefault(user => user.UserName.Equals(userName));
            }
        }
        public static int? AddUser(CustomerDto user)
        {
            /* if (FindUserByEmail(user.Email) != null || FindUserByUserName(user.UserName) != null)
                 return null;*/

            using (var context = new ShopDbContext())
            {
                var addedUser = context.Customers.Add(new Customer(user));

                if (context.SaveChanges() == 0)
                    return null;

                return addedUser.Id;
            }
        }
        public static IEnumerable<Customer> GetAllUsers()
        {
            using (var context = new ShopDbContext())
            {
                return context.Customers.ToList();
            }
        }
    }
}