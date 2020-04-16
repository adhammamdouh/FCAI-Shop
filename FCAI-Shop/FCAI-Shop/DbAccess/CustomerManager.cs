using System.Collections.Generic;
using System.Linq;
using FCAI_Shop.DbAccess;
using FCAI_Shop.Dtos;

namespace FCAI_Shop.Models
{
    public static class CustomerManager
    {
        public static int? AddCustomer(Customer user)
        {

            if (ApplicationUserRepository.IsValidModel(user)) return null;

            using var context = new DatabaseManager().Create();
            var addedUser = context.Customers.Add(user).Entity;

            if (context.SaveChanges() == 0)
                return null;
            
            return addedUser.Id;
        }
        public static IEnumerable<CustomerDto> GetAllCustomers()
        {
            using var context = new DatabaseManager().Create();
            return context.Customers.ToList().Select(user => user.ToDto());
        }
    }
}