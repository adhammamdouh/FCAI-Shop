using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbContext
{
    public class AdminManager
    {
        private static readonly ApplicationDbContext Context = DatabaseManager.Context;

        public static Admin FindAdminById(int id)
        {
            return Context.Admins.FirstOrDefault(admin => admin.Id == id);
        }

        public static Admin FindAdminByEmail(string email)
        {
            return Context.Admins.FirstOrDefault(admin => admin.Email.Equals(email));
        }
        public static Admin FindAdminByUserName(string adminName)
        {
            return Context.Admins.FirstOrDefault(admin => admin.UserName.Equals(adminName));
        }
        public static int? AddAdmin(Admin admin)
        {
            /*if (FindAdminByEmail(Admin.Email) != null || FindAdminByUserName(Admin.UserName) != null)
                return null;*/
            Context.Admins.Add(admin); 

            if (Context.SaveChanges() == 0) 
                return null; // returns number of affected rows

            return admin.Id;
        }
        public static IEnumerable<Admin> GetAllAdmins()
        {
            return Context.Admins.ToList();
        }
    }
}