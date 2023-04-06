using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.DTO.Cart;
using Shop.Application.DTO.Category;
using Shop.Application.DTO.Product;
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

                mc.CreateMap<Product, AddProductDto>().ReverseMap();
                mc.CreateMap<Product, ResponseProductDto>();

                mc.CreateMap<Cart, CartDto>();
            });
            IMapper mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
