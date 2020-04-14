using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FCAI_Shop.Utility;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;
using FCAI_Shop.DbContext;

namespace FCAI_Shop.Controllers
{

    /// <summary>
    /// Controller for users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        //private UserManager UserManager; // for class diagram only
        //public User user;
        /// <summary>
        /// Registers for a new user.
        /// </summary>
        /// <param name="user"></param>
        [Route("Register")]
        public IHttpActionResult Register([FromBody] ApplicationUserDto user)
        {
            try
            {
                int? id = null;
                if (user.Role == Roles.Customer) 
                    id = CustomerManager.AddUser(new Customer(user));
                else if (user.Role == Roles.ShopOwner)
                    id = ShopOwnerManager.AddUser(new ShopOwner(user));

                if (id == null) throw new Exception();
            }
            catch (Exception )
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed To Add User"));
            }

            return Ok("Registered successfully!");
        }
        
    }
}
