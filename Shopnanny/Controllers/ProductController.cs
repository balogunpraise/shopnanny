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
        public async Task<IActionResult> AddProduct([FromBody]ProductViewModel model)
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
                    CategoryId = model.CategoryId,
                    ProductImages = new List<ProductImage>()
                    {
                        new ProductImage{ImageUrl = model.ProductImageUrl}
                    }
                };

                await _productRepository.AddProduct(product);
                return RedirectToAction("Index", new { result = "Product was successfull added" });
            }
            return RedirectToAction("Index", new {error = "Product was not added"});
        }
    }
}
