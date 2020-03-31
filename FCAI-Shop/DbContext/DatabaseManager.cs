using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbContext
{
    public class DatabaseManager : IDisposable
    {
        private ApplicationDbContext _context;

        public ApplicationDbContext Create()
        {
            _context = new ApplicationDbContext();
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}