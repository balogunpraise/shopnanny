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

        public async Task<string> AddCategory(string categoryName)
        {
            var alreadyExists = await _context.Categories.
                Where(x => x.Name.Trim().Equals(categoryName, StringComparison.InvariantCultureIgnoreCase))
                .SingleOrDefaultAsync();

            if(alreadyExists == null)
            {
                var entity = await _context.AddAsync(categoryName);
                await _context.SaveChangesAsync();
                return entity.Entity;
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


        public async Task<Category> GetCategory(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);    
        }

        public async Task DeletCategory(int id)
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
