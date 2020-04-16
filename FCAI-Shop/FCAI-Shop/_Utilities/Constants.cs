using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCAI_Shop._Utilities
{
    public static class Constants
    {
        public const int DefaultStringLength = 256;

        public static class Roles
        {
            // Save all roles in lowercase strings
            public const string Admin = "admin";
            public const string ShopOwner = "shop_owner";
            public const string Customer = "customer";
        }
    }
}