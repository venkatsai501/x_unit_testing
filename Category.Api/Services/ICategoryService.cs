using System.Collections.Generic;
using System.Threading.Tasks;
using Category.Api.Models;

namespace Category.Api.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryModel>> GetAllAsync();
        Task AddAsync(CategoryModel category);
    }
}
