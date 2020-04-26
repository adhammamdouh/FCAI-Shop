using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FCAI_Shop.Services;
using FCAI_Shop.Utilities;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;
using Microsoft.Extensions.Options;
using FCAI_Shop.DbAccess;

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
        private IUserService _userService;
        public UserController(
           IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody]AuthenticateDto model)
        {
            var user = ApplicationUserManager.ValidateUser(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var expires = DateTime.Now.AddDays(1);
            var token = _userService.Authenticate(user, expires);

            return Ok(new
            {
                token,
                expires
            });
        }

        //private UserManager UserManager; // for class diagram only
        //public User user;
        /// <summary>
        /// Registers for a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] ApplicationUserDto user)
        {
            user.Password = Procedures.HashPassword(user.Password);
            try
            {
                int? id;

                if (user.Role.ToLower() == Constants.Roles.Customer.ToLower())
                    id = CustomerManager.AddCustomer(new Customer(user));
                else if (user.Role.ToLower() == Constants.Roles.ShopOwner.ToLower())
                    id = ShopOwnerManager.AddShopOwner(new ShopOwner(user));
                else
                    return Problem($"Role is invalid, must be either {Constants.Roles.Customer} or {Constants.Roles.ShopOwner}");

                if (id == null) throw new Exception();
            }
            catch (Exception)
            {
                return Problem("Failed To Add User", null, (int)System.Net.HttpStatusCode.InternalServerError);
            }

            return Ok($"{user.Role} added!");
        }
    }
}