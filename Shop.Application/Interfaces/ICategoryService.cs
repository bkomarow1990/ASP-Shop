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
        Task<List<CategoryDto>> GetAllAsync(bool isOnlyWithParent);
        Task EditCategory(EditCategoryDto categoryDto);
        Task<CategoryWithSubCategoriesDto> GetCategoryWithSubCategories(Guid categoryId); 
        Task<List<CategoryWithSubCategoriesDto>> GetAllWithSubCategoriesAsync();
        Task<Guid?> CreateCategory(AddCategoryDto categoryDto);
        Task DeleteCategory(Guid categoryId);
    }
}
