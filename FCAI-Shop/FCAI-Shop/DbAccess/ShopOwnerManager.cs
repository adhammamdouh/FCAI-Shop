using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;

namespace FCAI_Shop.DbAccess
{
    public static class ShopOwnerManager
    {
        public static int? AddShopOwner(ShopOwner user)
        {
            using var context = new ShopDbContext();
            var addedUser = context.ShopOwners.Add(user).Entity;

            if (context.SaveChanges() == 0)
                return null;

            return addedUser.Id;
        }

        public static IEnumerable<ShopOwnerDto> GetAllShopOwners()
        {
            using var context = new ShopDbContext();
            return context.ShopOwners.ToList().Select(user => user.ToDto());
        }
    }
}