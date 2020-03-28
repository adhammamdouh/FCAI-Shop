using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbContext
{
    public class AdminManager
    {
        private static ApplicationDbContext context = Database.context;

        public static Admin FindAdminById(int Id)
        {
            return context.Admins.Single(Admin => Admin.Id == Id);
        }

        public static Admin FindAdminByEmail(String Email)
        {
            return context.Admins.Single(Admin => Admin.Email == Email);
        }
        public static Admin FindAdminByUserName(String AdminName)
        {
            return context.Admins.Single(Admin => Admin.Username == AdminName);
        }
        public static int? AddAdmin(Admin Admin)
        {
            if (FindAdminByEmail(Admin.Email) != null || FindAdminByUserName(Admin.Username) != null)
                return null;

            context.Admins.Add(Admin);
            return Admin.Id;
        }
    }
}