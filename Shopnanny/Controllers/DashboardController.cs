using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopnanny.Core.Application.Constants;
using Shopnanny.Core.Application.Interfaces;
using Shopnanny.Core.Entities;

namespace Shopnanny.Controllers
{
   
    public class DashboardController : Controller
    {
        private readonly IProductRepository _productRepository;

        public DashboardController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        
        [Authorize(Roles = RoleConstants.GlobalAdmin)]
        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productRepository.GetAllProducts();
            ViewBag.Product = products;
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
