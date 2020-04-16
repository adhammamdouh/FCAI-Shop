using FCAI_Shop.DbAccess;
using FCAI_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace FCAI_Shop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public string Online()
        {

            return "Api is online.";
        }
    }
}