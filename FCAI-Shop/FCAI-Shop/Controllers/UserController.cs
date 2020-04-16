using System;
using System.Net;
using FCAI_Shop._Utilities;
using FCAI_Shop.DbAccess;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCAI_Shop.Controllers
{
    /// <summary>
    /// Controller for users
    /// </summary>
    [Authorize(Roles = Constants.Roles.Admin + "," + Constants.Roles.Customer + "," + Constants.Roles.ShopOwner)]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        //private UserManager UserManager; // for class diagram only
        //public User user;
        /// <summary>
        /// Registers for a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [AllowAnonymous]
        [Route("Register")]
        public IActionResult Register([FromBody] ApplicationUserDto user)
        {
            try
            {
                int? id = null;

                if (user.Role.ToLower() == Constants.Roles.Customer)
                    id = CustomerManager.AddCustomer(new Customer(user));
                else if (user.Role.ToLower() == Constants.Roles.Customer)
                    id = ShopOwnerManager.AddCustomer(new ShopOwner(user));

                if (id == null) throw new Exception();
            }
            catch (Exception)
            {
                return Problem("Failed To Add User", null, (int) HttpStatusCode.InternalServerError);
            }

            return Ok();
        }
    }
}