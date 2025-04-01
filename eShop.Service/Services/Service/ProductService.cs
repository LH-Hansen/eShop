using eShop.Repository.Entities;
using eShop.Service.Services.Generics.Generic;

namespace eShop.Service.Services.Service
{
    public class ProductService(IGenericSearchService<Product> personSearchService)
    {
        private readonly IGenericSearchService<Product> _productService = personSearchService;

        public async Task<IEnumerable<Product>> SearchPeopleAsync(string searchTerm, int page, int pageSize) => await _productService.GetPaginatedSearchAsync(page, pageSize, searchTerm);

    }
}
