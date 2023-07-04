using Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.Category;
using MediatR;
using Shop.Application.Common.Products.Commands;
using Shop.Application.Common.Products.Queries;

namespace Shop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _mediator;

        public CategoryService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<CategoryDto>> GetAllAsync(bool isOnlyWithParent)
        {
            return await _mediator.Send(new GetCategoriesQuery(isOnlyWithParent));
        }

        public async Task EditCategory(EditCategoryDto categoryDto)
        {
            await _mediator.Send(new EditCategoryCommand(categoryDto));
        }

        public async Task<CategoryWithSubCategoriesDto> GetCategoryWithSubCategories(Guid categoryId)
        {
            return await _mediator.Send(new GetCategoryWithSubCategoriesQuery(categoryId));
        }

        public async Task<List<CategoryWithSubCategoriesDto>> GetAllWithSubCategoriesAsync()
        {
            return await _mediator.Send(new GetCategoriesWithSubCategoriesQuery());
        }

        public async Task<Guid?> CreateCategory(AddCategoryDto categoryDto)
        {
            return await _mediator.Send(new CreateCategoryCommand(categoryDto));
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            await _mediator.Send(new DeleteCategoryCommand(categoryId));
        }
    }
}
