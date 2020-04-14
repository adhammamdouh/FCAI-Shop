using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FCAI_Shop.Utility;
using FCAI_Shop.DbContext;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;


namespace FCAI_Shop.Controllers
{

    /// <summary>
    /// Controller for admins
    /// </summary>
    [Authorize(Roles = Roles.Admin)]
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        //private AdminManager AdminManager; // for class diagram only
        // GET
        // API/User/GetAllUsers

        /// <summary>
        /// Gets all application users (Admins and Users) but requires admin privilege.
        /// </summary>
        /// <returns></returns>
        [Route("GetAllApplicationUsers")]
        public IEnumerable<ApplicationUserDto> GetAllApplicationUsers()
        {

            return ApplicationUserManager.GetAllApplicationUsers();
        }

        /// <summary>
        /// Gets all admins but requires admin privilege.
        /// </summary>
        /// <returns></returns>
        [Route("GetAllAdmins")]
        public IEnumerable<AdminDto> GetAllAdmins()
        {
            //return AdminManager.GetAllAdmins().Select(admin => admin.ToViewModel());
            return AdminManager.GetAllAdmins().Select(admin => admin.ToDto());
        }

        /// <summary>
        /// Gets all users but requires admin privilege.
        /// </summary>
        /// <returns></returns>
        [Route("GetAllUsers")]
        public IEnumerable<CustomerDto> GetAllUsers()
        {
            return CustomerManager.GetAllUsers().Select(user => user.ToDto());
        }

        // no one can register admin unless if he was an admin
        /// <summary>
        /// Registers for admin but requires admin privilege.
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Route("Register")]
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

            
            return Ok("Admin registered sucessfully!");
        }
    }


}
