using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class ProductService : GenericSearchService<Product>, IProductService, IGenericSearchService<Product>
    {
        private readonly IGenericSearchService<Product> _searchService;

        public ProductService(IGenericSearchService<Product> searchService, IGenericRepository<Product> repository) : base(searchService, repository)
        {
            _searchService = searchService;
        }

        public async Task<IEnumerable<Product>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) => await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
    }
}
