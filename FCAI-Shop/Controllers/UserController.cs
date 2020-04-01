using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FCAI_Shop.Constants;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;

namespace FCAI_Shop.Controllers
{

    [Authorize(Roles = Roles.Admin + "," + Roles.User)]
    public class UserController : ApiController
    {
        //private UserManager UserManager; // for class diagram only
        //public User user;
        [AllowAnonymous]
        [Route("api/User/Register")]
        public IHttpActionResult Register([FromBody] UserDto user)
        {
            try
            {
                var id = UserManager.AddUser(user);
                if (id == null) throw new Exception();
            }
            catch (Exception)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed To Add User"));
            }

            return Ok();
        }
        
    }
}
