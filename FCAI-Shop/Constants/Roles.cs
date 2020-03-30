using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace FCAI_Shop.Constants
{
    public static class Roles
    {
        public static string Admin => "Admin";
        public static string User => "User";

        public static string AddRole(string currentRoles, string newRole)
        {
            if (currentRoles.IsNullOrWhiteSpace())
                return newRole;

            return currentRoles + ", " + newRole;
        }
    }
}