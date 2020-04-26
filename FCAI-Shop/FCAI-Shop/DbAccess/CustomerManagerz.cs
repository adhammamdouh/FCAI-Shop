using FCAI_Shop.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace FCAI_Shop.Models
{
    public static class CustomerManager
    {
        public static int? AddCustomer(Customer user)
        {
            using var context = new ShopDbContext();
            var addedUser = context.Customers.Add(user).Entity;

            if (context.SaveChanges() == 0)
                return null;

            return addedUser.Id;
        }
        public static IEnumerable<CustomerDto> GetAllCustomers()
        {
            using var context = new ShopDbContext();
            return context.Customers.ToList().Select(user => user.ToDto());
        }
    }
}