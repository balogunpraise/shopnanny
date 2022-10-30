using Shopnanny.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task DeleteProduct(string id);
        Task AddProductToCategory(string productId, string categoryName);
        Task<Product> UpdateProduct(string id, Product update);
        Task ToggleProductHotSale(string id);
        Task<List<Product>> GetAllHotSaleProducts();
        Task<Product> GetProductById(string id);
        Task<int> GetTotalProductCount();
    }
}
