using Microsoft.AspNetCore.Mvc;
using Shopnanny.Core.Application.Interfaces;
using Shopnanny.Core.Entities;
using Shopnanny.ViewModels;

namespace Shopnanny.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _cat;

        public CategoryController(ICategoryRepository cat)
        {
            _cat = cat;
        }
        public async Task<IActionResult> CategoryIndex()
        {
            var categories = await _cat.GetCategories();
            ViewBag.Categories = categories;
            return View();
        }

        public async Task<IActionResult> AddCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.CategoryName,
                    CreatedAt = DateTime.Now
                };
                var newCat = await _cat.AddCategory(category);
                return RedirectToAction("CategoryIndex");
            }
            return RedirectToAction("CategoryIndex");
        }
    }
}
