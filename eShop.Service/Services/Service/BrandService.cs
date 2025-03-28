using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class BrandService(IGenericRepository<Brand> brandRepository) : GenericService<Brand>(brandRepository), IBrandService
    {
        private readonly IGenericRepository<Brand> _brandRepository = brandRepository;

        public async Task<IEnumerable<Brand>> GetPaginatedSearchAsync(int page, int pageSize, string? searchTerm = null)
        {
            IEnumerable<Brand> brands = await _brandRepository.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                brands = brands.Where(b => b.Name.ToLower().Contains(searchTerm));
            }

            List<Brand> paginatedBrands = brands.Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();
            return paginatedBrands;
        }
    }
}
