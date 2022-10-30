using Microsoft.AspNetCore.Mvc;
using Shopnanny.Core.Application.Interfaces;
using Shopnanny.Core.Entities;
using Shopnanny.ViewModels;

namespace Shopnanny.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
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

        public async Task<IActionResult> AddProductToCategoryIndex(string id)
        {
            var product = await _productRepository.GetProductById(id);
            var category = await _categoryRepository.GetCategories();
            ViewBag.ProductName = product.Id;
            ViewBag.Categories = category;
            return View();
        }

        public async Task<IActionResult> AddProductToCategory(string id, string categoryName)
        {
            await _productRepository.AddProductToCategory(id, categoryName);
            return RedirectToAction("ProductIndex", "Dashboard", new { error = "Product was not added" });
        }
        public async Task<IActionResult> EditProduct(string id, ProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity,
                MinOrderQuantity = model.MinOrderQuantity,
                LowStockQuantity = model.LowStockQuantity,
                ProductImages = new List<ProductImage>()
                {
                    new ProductImage
                    {
                        ImageUrl = model.ProductImageUrl
                    }
                }
            };
            await _productRepository.UpdateProduct(id, product);
            return RedirectToAction("ProductIndex");
        }

        public async Task<IActionResult> ProductDetails(string id)
        {
            var product = await _productRepository.GetProductById(id);
            ViewBag.ProductDetails = product;
            return View();
        }


        public async Task<IActionResult> RemoveProduct(string id)
        {
            await _productRepository.DeleteProduct(id);
            return RedirectToAction("ProductIndex", "Dashboard");
        }

        public async Task<IActionResult> ToggleProductHotSale(string id)
        {
            await _productRepository.ToggleProductHotSale(id);
            return RedirectToAction("ProductIndex", "Dashboard");
        }
    }
}
