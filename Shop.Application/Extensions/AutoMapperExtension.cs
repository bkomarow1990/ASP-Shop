using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.DTO.Category;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Category, CategoryDto>().ReverseMap();
            });
            IMapper mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
