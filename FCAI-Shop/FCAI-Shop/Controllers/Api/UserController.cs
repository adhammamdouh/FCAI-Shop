using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using FCAI_Shop.Models;

namespace FCAI_Shop.Controllers.API
{

    public class UserController : ApiController
    {
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> x = UserManager.GetAllUsers().ToList();

            return x;
        }
    }
}
