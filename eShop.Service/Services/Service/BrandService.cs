using eShop.Repository.Entities;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.Service
{
    public class BrandService(IGenericSearchService<Brand> searhcService) : IGenericSearchService<Brand>, IBrandService
    {
        private readonly IGenericSearchService<Brand> _searchService = searhcService;

        public async Task<IEnumerable<Brand>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) => await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);


    }
}
