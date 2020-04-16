using System;
using System.Collections.Generic;
using System.Linq;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbAccess
{
    public static class AdminManager
    {

        public static int? AddAdmin(Admin admin)
        {

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