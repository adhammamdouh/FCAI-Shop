using FCAI_Shop.Dtos;
using FCAI_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCAI_Shop.DbContext
{
    public class ShopOwnerManager
    {
        public static int? AddUser(ShopOwnerDto user)
        {
            /* if (FindUserByEmail(user.Email) != null || FindUserByUserName(user.UserName) != null)
                 return null;*/

            using (var context = new ShopDbContext())
            {
                var addedOwner = context.ShopOwners.Add(new ShopOwner(user));

                if (context.SaveChanges() == 0)
                    return null;

                return addedOwner.Id;
            }
        }
    }
}