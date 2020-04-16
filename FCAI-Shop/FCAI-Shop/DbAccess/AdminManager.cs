using System;
using System.Collections.Generic;
using System.Linq;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbAccess
{
    public static class AdminManager
    {

        //private static Admin admin; // for class diagram only
        //private static DatabaseManager DbContext = new DatabaseManager(); // for class diagram only
        public static Admin FindAdminById(int id)
        {
            using var context = new DatabaseManager().Create();
            return context.Admins.FirstOrDefault(admin => admin.Id == id);

        }

        public static Admin FindAdminByEmail(string email)
        {
            using var context = new DatabaseManager().Create();
            return context.Admins.FirstOrDefault(admin => admin.Email.Equals(email));
        }
        public static Admin FindAdminByUserName(string adminName)
        {
            using var context = new DatabaseManager().Create();
            return context.Admins.FirstOrDefault(admin => admin.UserName.Equals(adminName));
        }
        public static int? AddAdmin(Admin admin)
        {

            if (ApplicationUserRepository.IsValidModel(admin)) return null;

            using var context = new DatabaseManager().Create();
            var addedAdmin = context.Admins.Add(admin).Entity;

            if (context.SaveChanges() == 0)
                return null; // returns number of affected rows

            return addedAdmin.Id;
        }
        public static IEnumerable<AdminDto> GetAllAdmins()
        {
            using var context = new DatabaseManager().Create();
            return context.Admins.ToList().Select(user => user.ToDto());
        }
    }
}