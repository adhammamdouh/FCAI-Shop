using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCAI_Shop.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCAI_Shop.Controllers
{
    /// <summary>
    /// Controller for admins
    /// </summary>
    [ApiController]
    [Authorize(Roles = Constants.Roles.Customer)]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
    }
}