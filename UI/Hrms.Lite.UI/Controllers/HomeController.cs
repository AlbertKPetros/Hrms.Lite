using Microsoft.AspNetCore.Mvc;

namespace Hrms.Lite.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
