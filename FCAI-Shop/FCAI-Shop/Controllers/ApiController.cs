using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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