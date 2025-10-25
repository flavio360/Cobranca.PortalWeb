using Microsoft.AspNetCore.Mvc;

namespace Cobranca.PortalWeb.Controllers.Home
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
