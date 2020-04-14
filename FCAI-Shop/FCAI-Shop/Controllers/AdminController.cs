using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FCAI_Shop._Utilities;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FCAI_Shop.DbAccess;

namespace FCAI_Shop.Controllers
{

    /// <summary>
    /// Controller for admins
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
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

            return ApplicationUserRepository.GetAllApplicationUsers();
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
        public IEnumerable<UserDto> GetAllUsers()
        {
            return UserManager.GetAllUsers().Select(user => user.ToDto());
        }

        // no one can register admin unless if he was an admin
        /// <summary>
        /// Registers for admin but requires admin privilege.
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Route("Register")]
        public ActionResult Register([FromBody] AdminDto admin)
        {
            try
            {
                var id = AdminManager.AddAdmin(admin);
                if (id == null) throw new Exception();
            }
            catch (Exception)
            {
                Problem("Failed To Add Admin", null, (int)HttpStatusCode.InternalServerError);
            }

            
            return Ok();
        }
    }


}
