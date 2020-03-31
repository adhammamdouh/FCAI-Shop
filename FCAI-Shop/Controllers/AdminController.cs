using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FCAI_Shop.Constants;
using FCAI_Shop.DbContext;
using FCAI_Shop.Models;
using FCAI_Shop.ViewModels;

namespace FCAI_Shop.Controllers
{

    [Authorize(Roles = Roles.Admin)]
    public class AdminController : ApiController
    {
        // GET
        // API/User/GetAllUsers

        [Route("api/Admin/GetAllApplicationUsers")]
        public IEnumerable<ApplicationUserViewModel> GetAllApplicationUsers()
        {
            return ApplicationUserRepository.GetAllApplicationUsers().Select(user => user.ToViewModel());
        }
        [Route("api/Admin/GetAllAdmins")]
        public IEnumerable<AdminViewModel> GetAllAdmins()
        {
            return AdminManager.GetAllAdmins().Select(admin => admin.ToViewModel());
        }
        [Route("api/Admin/GetAllUsers")]
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            return UserManager.GetAllUsers().Select(user => user.ToViewModel());
        }

        // no one can register admin unless if he was an admin
        [Route("api/Admin/Register")]
        public IHttpActionResult Register(Admin admin)
        {
            var id = AdminManager.AddAdmin(admin);
            if (id == null) return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed To Add Admin"));
            return Ok();
        }
    }
}
