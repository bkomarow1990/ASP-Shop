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
using Shop.Domain.Entities.Identity;
using Shop.Application.DTO.User.Admin;

namespace Shop.Application.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Category, CategoryDto>().ReverseMap();
                mc.CreateMap<Category, CategoryWithSubCategoriesDto>().ReverseMap();
                mc.CreateMap<EditCategoryDto, Category>();
                mc.CreateMap<AddCategoryDto, Category>();;

                mc.CreateMap<Product, AddProductDto>()
                    .ForMember(dest => dest.Image, opt => opt.Ignore())
                    .ReverseMap();
                mc.CreateMap<Product, EditProductDto>()
                    .ForMember(dest => dest.Image, opt => opt.Ignore())
                    // .ForMember(dest => dest.Image, opt => opt.Ignore())
                    .ReverseMap();
                mc.CreateMap<Product, ResponseProductDto>();
                mc.CreateMap<Product, DetailedProductDto>();

                mc.CreateMap<ApplicationUser, UserPageUserDto>()
                    .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.Name).ToList()));
                ;


            });
            IMapper mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
