using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FCAI_Shop.DbContext;
using FCAI_Shop.Models;
using FCAI_Shop.ViewModels;

namespace FCAI_Shop.Controllers
{

    //[Authorize(Roles = "Admin")]
    public class AdminController : ApiController
    {
        // GET
        // API/User/GetAllUsers

        //[Route("api/test/resource1")]
        public IEnumerable<ApplicationUserViewModel> GetAllUsers()
        {
            return ApplicationUserRepository.GetAllApplicationUsers().Select(user => user.ToViewModel());

        }
    }
}
