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
        Task DeleteProduct(int id);
        Task AddProductToCategory(int productId, string categoryName);
        Task<Product> UpdateProduct(int id, Product update);
    }
}
