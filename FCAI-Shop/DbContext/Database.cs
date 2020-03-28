using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbContext
{
    public static class Database
    {
        public static ApplicationDbContext context { get; } = new ApplicationDbContext();
    }
}