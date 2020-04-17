using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FCAI_Shop.Utilities;
using FCAI_Shop.Dtos;
using FCAI_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FCAI_Shop.DbAccess;

namespace FCAI_Shop.Controllers
{

    [ApiController]
    [AllowAnonymous]
    public class ApiController : ControllerBase
    {
        [Route("/")]
        [Route("/swagger")]
        public IActionResult Index()
        {
            return new RedirectResult("/docs");
        }
    }

}