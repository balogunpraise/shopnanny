using Shopnanny.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategory(string id);
        Task<string> AddCategory(Category categoryName);
        Task<List<Category>> GetCategories();
    }
}
