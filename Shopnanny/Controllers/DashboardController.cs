using Microsoft.AspNetCore.Mvc;

namespace Shopnanny.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
