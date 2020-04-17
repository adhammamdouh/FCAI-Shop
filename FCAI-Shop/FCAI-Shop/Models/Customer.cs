using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FCAI_Shop.Utilities;
using FCAI_Shop.Dtos;

namespace FCAI_Shop.Models
{
    [Table("Customers")]
    public class Customer : ApplicationUser
    {


        public Customer()
        {

        }

        public Customer(ApplicationUserDto user) : base(user, Constants.Roles.Customer)
        {

        }
        public Customer(CustomerDto customer) : base(customer, Constants.Roles.Customer)
        {
        }

        public new CustomerDto ToDto()
        {
            return new CustomerDto
            { Email = Email, Name = Name, Password = "hidden", UserName = UserName,Role = Role };
        }

    }

}