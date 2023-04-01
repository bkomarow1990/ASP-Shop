using Shop.Application.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<List<CategoryWithSubCategoriesDto>> GetAllWithSubCategoriesAsync();
        Task<Guid?> CreateCategory(AddCategoryDto categoryDto);
        Task DeleteCategory(Guid categoryId);
    }
}
