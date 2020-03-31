using System.Net;
using System.Net.Http;
using System.Web.Http;
using FCAI_Shop.Constants;
using FCAI_Shop.Models;
using FCAI_Shop.ViewModels;

namespace FCAI_Shop.Controllers
{

    [Authorize(Roles = Roles.Admin + "," + Roles.User)]
    public class UserController : ApiController
    {
        [AllowAnonymous]
        [Route("api/User/Register")]
        public IHttpActionResult Register(UserViewModel user)
        {
           // user.UserRoles = Roles.User;
            //var id = UserManager.AddUser(user);
            //if (id == null) return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed To Add Admin"));
            return Ok();
        }
        
    }
}
