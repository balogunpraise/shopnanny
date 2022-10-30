using Microsoft.AspNetCore.Mvc;
using Shopnanny.Core.Application.Interfaces;

namespace Shopnanny.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ShopController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> ShopIndex()
        {
            var products = await _productRepository.GetAllProducts();
            return View(products);
        }
    }
}
