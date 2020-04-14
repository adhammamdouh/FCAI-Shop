using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using FCAI_Shop.Utility;
using FCAI_Shop.DbContext;
using FCAI_Shop.Dtos;

namespace FCAI_Shop.Models
{
    [Table("Customers")]
    public class Customer : ApplicationUser
    {
        private Customer()
        {

        }
        public Customer(CustomerDto user) : base(user, Roles.Customer)
        {
        }
        public new CustomerDto ToDto()
        {
            CustomerDto dt = (CustomerDto)base.ToDto();
            return dt;
        }

    }
}