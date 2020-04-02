using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
#pragma warning disable 1591
namespace FCAI_Shop.Constants
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public static string AddRole(string currentRoles, string newRole)
        {
            if (currentRoles.IsNullOrWhiteSpace())
                return newRole;

            return currentRoles + ", " + newRole;
        }
    }
}