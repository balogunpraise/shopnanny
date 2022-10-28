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
            var products = await _productRepository.GetAllProducts();
            /*var products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Head Phone",
                    Description = "Just another head phone",
                    Price = 20000m,
                    Quantity = 10,
                    MinOrderQuantity = 1,
                    LowStockQuantity = 2,
                    ProductImages = new List<ProductImage>()
                    {
                        new ProductImage
                        {
                            ImageUrl = "https://kg-s3-assets.s3.amazonaws.com/subfolder/d3da922c-302a-4e58-abb0-3884ea40ef0c.jpeg"
                        }
                    }
                },
                new Product
                {
                    Id=2,
                    Name = "Laptop",
                    Description = "Just another laptop",
                    Price = 400000m,
                    Quantity = 5,
                    MinOrderQuantity = 1,
                    LowStockQuantity = 1,
                     ProductImages = new List<ProductImage>()
                    {
                        new ProductImage
                        {
                            ImageUrl = "https://www-konga-com-res.cloudinary.com/w_auto,f_auto,fl_lossy,dpr_auto,q_auto/media/catalog/product/G/M/59229_1647601818.jpg"
                        }
                    }
                },
                new Product
                {
                    Id = 3,
                    Name = "Power Bank",
                    Description = "Just another power bank",
                    Price = 15000m,
                    Quantity = 15,
                    MinOrderQuantity = 2,
                    LowStockQuantity = 5,
                     ProductImages = new List<ProductImage>()
                    {
                        new ProductImage
                        {
                            ImageUrl = "https://media.istockphoto.com/photos/power-bank-isolated-on-white-background-picture-id1126642401?k=20&m=1126642401&s=612x612&w=0&h=bOFc8Ifq6vwxIG_CY9AzTXy1peuY84YYUeDyRLTP8QM="
                        }
                    }
                },
            };*/
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
