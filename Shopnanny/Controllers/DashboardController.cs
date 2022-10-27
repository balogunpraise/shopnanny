using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> ProductIndex()
        {
            //var products = await _productRepository.GetAllProducts();
            var products = new List<Product>()
            {
                new Product
                {
                    Name = "Head Phone",
                    Description = "Just another head phone",
                    Price = 20000m,
                    Quantity = 10,
                    MinOrderQuantity = 1,
                    LowStockQuantity = 2,
                },
                new Product
                {
                    Name = "Laptop",
                    Description = "Just another laptop",
                    Price = 400000m,
                    Quantity = 5,
                    MinOrderQuantity = 1,
                    LowStockQuantity = 1,
                },
                new Product
                {
                    Name = "Power Bank",
                    Description = "Just another power bank",
                    Price = 15000m,
                    Quantity = 15,
                    MinOrderQuantity = 2,
                    LowStockQuantity = 5,
                },
            };
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
