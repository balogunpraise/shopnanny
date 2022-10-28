using Microsoft.AspNetCore.Mvc;
using Shopnanny.Core.Application.Interfaces;
using Shopnanny.Core.Entities;
using Shopnanny.ViewModels;

namespace Shopnanny.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index(string error, string result)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    MinOrderQuantity = model.MinOrderQuantity,
                    LowStockQuantity = model.LowStockQuantity,
                    //CategoryId = model.CategoryId,
                    ProductImages = new List<ProductImage>()
                    {
                        new ProductImage{ImageUrl = model.ProductImageUrl}
                    }
                };

                await _productRepository.AddProduct(product);
                return RedirectToAction("ProductIndex", "Dashboard", new { result = "Product was successfull added" });
            }
            return RedirectToAction("Index", new {error = "Product was not added"});
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _productRepository.GetProductById(id);
            ViewBag.ProductDetails = product;
            return View();
        }


        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            return RedirectToAction("ProductIndex", "Dashboard");
        }

        public async Task<IActionResult> ToggleProductHotSale(int id)
        {
            await _productRepository.ToggleProductHotSale(id);
            return RedirectToAction("ProductIndex", "Dashboard");
        }
    }
}
