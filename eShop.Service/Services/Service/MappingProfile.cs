using AutoMapper;
using eShop.Repository.Entities;
using eShop.Service.DTO;

namespace eShop.Service.Services.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();


            CreateMap<BrandDto, Brand>();
        }


    }
}
