using Microsoft.EntityFrameworkCore;
using Shopnanny.Core.Application.Interfaces;
using Shopnanny.Core.Entities;
using Shopnanny.Infrastructure.Data;

namespace Shopnanny.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                var productAlreadyExists = await _context.Products.
                Where(x => x.Name.ToLower() == product.Name.ToLower()).SingleOrDefaultAsync();
                if (productAlreadyExists != null)
                {
                    productAlreadyExists.Quantity += product.Quantity;
                    await _context.SaveChangesAsync();
                    return productAlreadyExists;
                }
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Product> UpdateProduct(string id, Product update)
        {
            var product = await _context.Products.FindAsync(id);
            if(product != null)
            {
                product.Name = update.Name.Trim();
                product.Quantity = update.Quantity;
                product.Price = update.Price;
                product.Description = update.Description;
                product.LowStockQuantity = update.LowStockQuantity;
                product.UpdatedAt = DateTime.Now;
                product.MinOrderQuantity = update.MinOrderQuantity;
                product.ProductImages = update.ProductImages;
            }
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddProductToCategory(string productId, string categoryName)
        {
            var category = await _context.Categories.
                    Where(x => x.Name.ToUpper() == categoryName.ToUpper())
                    .FirstOrDefaultAsync();
            var product = await _context.Products.FindAsync(productId);
            if (category != null && product != null)
            {
                product.Category.Id = category.Id;
                product.Category = category;
                await _context.SaveChangesAsync();
            }

        }

        public async Task ToggleProductHotSale(string id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    product.HotSale = !product.HotSale;
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.Include(x =>x.ProductImages).ToListAsync();
        }

        public async Task<List<Product>> GetAllHotSaleProducts()
        {
            return await _context.Products.Where(x => x.HotSale).Include(c => c.ProductImages).ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _context.Products
                .Include(x => x.ProductImages).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<int> GetTotalProductCount()
        {
            return await _context.Products.CountAsync();
        }

    }
}
