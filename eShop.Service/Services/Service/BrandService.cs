using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class BrandService : GenericSearchService<Brand>, IBrandService, IGenericService<Brand>
    {
        private readonly IGenericSearchService<Brand> _searchService;

        public BrandService(IGenericSearchService<Brand> searchService, IGenericRepository<Brand> repository) : base(searchService, repository)
        {
            _searchService = searchService;
        }

        public async Task<IEnumerable<BrandDTO>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm)
        {
            IEnumerable<Brand> brands = await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);

            return brands.Select(brand => new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name
            });
        }

        public async Task<IEnumerable<BrandDTO>> GetAllAsync()
        {
            var brands = await _searchService.GetAllAsync();

            return brands.Select(brand => new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name
            });
        }


        private static BrandDTO ReturnDTO(Brand brand)
        {
            return new BrandDTO
            {
                Id = brand.Id,
                Name = brand.Name,
                Description = brand.Description,
                Products = brand.Products,
            };
        }

        private static Brand ConvertBrand(BrandDTO brandDTO)
        {
            return new Brand
            {
                Id = brandDTO.Id,
                Name = brandDTO.Name,
                Description = brandDTO.Description,
                Products = brandDTO.Products,
            };
        }


    }
}
