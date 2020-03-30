using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FCAI_Shop.Models;
using FCAI_Shop.ModelViews;

namespace FCAI_Shop.Controllers
{
    // GET
    // API/User/GetAllUsers

    //[Route("api/test/resource1")]
    [Authorize(Roles = "Admin")]
    public class UserController : ApiController
    {
        public IEnumerable<User> GetAllUsers()
        {
            return UserManager.GetAllUsers();
        }
    }
}
