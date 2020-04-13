using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Utility;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;
#pragma warning disable 1591

namespace FCAI_Shop.DbContext
{
    public class AdminManager
    {

        //private static Admin admin; // for class diagram only
        //private static DatabaseManager DbContext = new DatabaseManager(); // for class diagram only
        public static Admin FindAdminById(int id)
        {
            using (var context = new ShopDbContext())
            {
                return context.Admins.FirstOrDefault(admin => admin.Id == id);
            }
            
        }

        public static Admin FindAdminByEmail(string email)
        {
            using (var context = new ShopDbContext())
            {
                return context.Admins.FirstOrDefault(admin => admin.Email.Equals(email));
            }
        }
        public static Admin FindAdminByUserName(string adminName)
        {
            using (var context = new ShopDbContext())
            {
                return context.Admins.FirstOrDefault(admin => admin.UserName.Equals(adminName));
            }
        }
        public static int? AddAdmin(AdminDto admin)
        {
            /*if (FindAdminByEmail(Admin.Email) != null || FindAdminByUserName(Admin.UserName) != null)
                return null;*/
            
            using (var context = new ShopDbContext())
            {
                var addedAdmin = context.Admins.Add(new Admin(admin));

                if (context.SaveChanges() == 0)
                    return null; // returns number of affected rows

                return addedAdmin.Id;
            }
        }
        public static IEnumerable<Admin> GetAllAdmins()
        {
            using (var context = new ShopDbContext())
            {
                return context.Admins.ToList();
            }
        }
    }
}