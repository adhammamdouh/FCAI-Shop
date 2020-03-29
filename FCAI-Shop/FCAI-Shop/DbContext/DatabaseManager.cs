using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbContext
{
    public static class DatabaseManager
    {
        public static ApplicationDbContext Context { get; } = new ApplicationDbContext();

        public static void Dispose()
        {
            Context.Dispose();
        }
    }
}