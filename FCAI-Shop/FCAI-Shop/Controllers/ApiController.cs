using FCAI_Shop.DbAccess;
using FCAI_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace FCAI_Shop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public string Online()
        {
            AdminManager.AddAdmin(new Admin
            {
                Email = "belal", Name = "Belal", Password = "123", Role = "admin", UserName = "belal"
            });
            CustomerManager.AddCustomer(new Customer
            {
                Email = "ahmed",
                Name = "ahmed",
                Password = "123",
                Role = "customer",
                UserName = "ahmed"
            });
            return "Api is online.";
        }
    }
}