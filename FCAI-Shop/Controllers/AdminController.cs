using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FCAI_Shop.Constants;
using FCAI_Shop.DbContext;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;


namespace FCAI_Shop.Controllers
{

    [Authorize(Roles = Roles.Admin)]
    public class AdminController : ApiController
    {
        //private AdminManager AdminManager; // for class diagram only
        // GET
        // API/User/GetAllUsers

        [Route("api/Admin/GetAllApplicationUsers")]
        public IEnumerable<ApplicationUserDto> GetAllApplicationUsers()
        {

            return ApplicationUserRepository.GetAllApplicationUsers();
        }

        [Route("api/Admin/GetAllAdmins")]
        public IEnumerable<AdminDto> GetAllAdmins()
        {
            //return AdminManager.GetAllAdmins().Select(admin => admin.ToViewModel());
            return AdminManager.GetAllAdmins().Select(admin => admin.ToDto());
        }

        [Route("api/Admin/GetAllUsers")]
        public IEnumerable<UserDto> GetAllUsers()
        {
            return UserManager.GetAllUsers().Select(user => user.ToDto());
        }

        // no one can register admin unless if he was an admin
        [Route("api/Admin/Register")]
        public IHttpActionResult Register([FromBody] AdminDto admin)
        {
            try
            {
                var id = AdminManager.AddAdmin(admin);
                if (id == null) throw new Exception();
            }
            catch (Exception)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed To Add Admin"));
            }

            return Ok();
        }
    }


}
