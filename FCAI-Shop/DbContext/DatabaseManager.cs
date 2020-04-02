using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FCAI_Shop.Models;
#pragma warning disable 1591

namespace FCAI_Shop.DbContext
{
    public class DatabaseManager : IDisposable
    {
        private ApplicationDbContext _context; 

        public ApplicationDbContext Create()
        {
            return _context = ApplicationDbContext.Create();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}