using Microsoft.EntityFrameworkCore;
using Shopnanny.Core.Application.Interfaces;
using Shopnanny.Core.Entities;
using Shopnanny.Infrastructure.Data;

namespace Shopnanny.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddCategory(Category categoryName)
        {
            var alreadyExists = await _context.Categories.
                Where(x => x.Name.Trim().ToLower() == categoryName.Name.ToLower())
                .SingleOrDefaultAsync();

            if(alreadyExists == null)
            {
                var entity = await _context.Categories.AddAsync(categoryName);
                await _context.SaveChangesAsync();
                return entity.Entity.Name;
            }
            return String.Empty;
        }

        public async Task UpdateCategory(string newCategoryName)
        {
            var alreadyExists = await _context.Categories.
                Where(x => x.Name.Trim().Equals(newCategoryName, StringComparison.InvariantCultureIgnoreCase))
                .SingleOrDefaultAsync();
            if(alreadyExists != null)
            {
                alreadyExists.Name = newCategoryName;
                alreadyExists.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }


        public async Task<Category> GetCategory(string id)
        {
            return await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);    
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task DeletCategory(string id)
        {
            var category = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
