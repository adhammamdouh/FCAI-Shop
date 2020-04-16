using FCAI_Shop.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCAI_Shop.Utilities
{
    public static class Constants
    {
        public const int DefaultStringLength = 256;

        public static class Roles
        {
            // Save all roles in lowercase strings
            public const string Admin = "Admin";
            public const string ShopOwner = "ShopOwner";
            public const string Customer = "Customer";
        }
    }
}