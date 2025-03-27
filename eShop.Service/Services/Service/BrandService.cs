using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.GenericSerivice;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class BrandService : GenericService<Brand>, IBrandService
    {
        private readonly IGenericRepository<Brand> _brandRepository;

        public BrandService(IGenericRepository<Brand> brandRepository) : base(brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Brand>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm = null)
        {
            IEnumerable<Brand> brands = await _brandRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                brands = brands.Where(b => b.Name.Contains(searchTerm));
            }

            var paginatedBrands = brands.Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();
            return paginatedBrands;
        }
    }
}
