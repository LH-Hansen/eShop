using AutoMapper;
using eShop.Repository.Entities;
using eShop.Service.DTO;
using eShop.Service.DTO.Product;
using eShop.Service.DTO.Review;

namespace eShop.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Review, ReviewUpsertDto>();
            CreateMap<Review, ReviewDto>();

            CreateMap<BrandDto, Brand>();
            CreateMap<SubCategoryDto, SubCategory>();
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductUpsertDto, Product>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name));

            CreateMap<Product, ProductUpsertDto>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
                .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategory.Id));

            CreateMap<Product, ProductUpsertDto>()
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
                .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategory.Id));

            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<ReviewUpsertDto, Review>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());

            CreateMap<ReviewUpsertDto, Product>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember<Brand>(dest => dest.Brand, opt => opt.Ignore())
                 .ForMember(dest => dest.SubCategory, opt => opt.Ignore());
        }
    }
}
