using Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.Category;
using MediatR;
using Shop.Application.Common.Category.Commands;
using Shop.Application.Common.Category.Queries;

namespace Shop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediator _mediator;

        public CategoryService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _mediator.Send(new GetCategoriesQuery());
        }

        public async Task<Guid?> CreateCategory(AddCategoryDto categoryDto)
        {
            return await _mediator.Send(new CreateCategoryCommand(categoryDto));
        }
    }
}
