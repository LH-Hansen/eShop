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


            CreateMap<BrandDto, Brand>();
            CreateMap<SubCategoryDto, SubCategory>();
        }
    }
}
