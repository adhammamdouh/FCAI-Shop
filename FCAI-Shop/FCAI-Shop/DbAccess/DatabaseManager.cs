using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbAccess
{
    public class DatabaseManager : IDisposable
    {
        private ShopDbContext _context; 

        public ShopDbContext Create()
        {
            return _context = ShopDbContext.Create();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}