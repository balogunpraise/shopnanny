using Microsoft.AspNetCore.Mvc;

namespace Shopnanny.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult Inventory()
        {
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }

        public IActionResult Sales()
        {
            return View();
        }


        public IActionResult Orders()
        {
            return View();
        }
    }
}
