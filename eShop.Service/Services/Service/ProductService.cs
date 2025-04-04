using eShop.Repository.Entities;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class ProductService(IGenericSearchService<Product> searchService) : IGenericSearchService<Product>, IProductService
    {
        private readonly IGenericSearchService<Product> _searchService = searchService;

        public async Task<IEnumerable<Product>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) => await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);

    }
}
