using AutoMapper;
using eShop.Repository.Entities;
using eShop.Service.DTO;

namespace eShop.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Review, ReviewDto>();

            CreateMap<BrandDto, Brand>();
            CreateMap<SubCategoryDto, SubCategory>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<ReviewDto, ReviewDto>();
        }
    }
}
