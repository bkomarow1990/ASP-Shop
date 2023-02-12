using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.DTO.Category;

namespace Shop.Application.Common.Category.Commands
{
    public record CreateCategoryCommand(AddCategoryDto CategoryDto) : IRequest<Guid?>;
}
