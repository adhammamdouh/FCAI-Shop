using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbContext
{
    public class AdminManager
    {
        

        public static Admin FindAdminById(int id)
        {
            using (var context = new DatabaseManager().Create())
            {
                return context.Admins.FirstOrDefault(admin => admin.Id == id);
            }
            
        }

        public static Admin FindAdminByEmail(string email)
        {
            using (var context = new DatabaseManager().Create())
            {
                return context.Admins.FirstOrDefault(admin => admin.Email.Equals(email));
            }
        }
        public static Admin FindAdminByUserName(string adminName)
        {
            using (var context = new DatabaseManager().Create())
            {
                return context.Admins.FirstOrDefault(admin => admin.UserName.Equals(adminName));
            }
        }
        public static int? AddAdmin(Admin admin)
        {
            /*if (FindAdminByEmail(Admin.Email) != null || FindAdminByUserName(Admin.UserName) != null)
                return null;*/
            using (var context = new DatabaseManager().Create())
            {
                context.Admins.Add(admin);

                if (context.SaveChanges() == 0)
                    return null; // returns number of affected rows

                return admin.Id;
            }
        }
        public static IEnumerable<Admin> GetAllAdmins()
        {
            using (var context = new DatabaseManager().Create())
            {
                return context.Admins.ToList();
            }
        }
    }
}