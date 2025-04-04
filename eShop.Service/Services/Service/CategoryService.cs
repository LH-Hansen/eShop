using eShop.Repository.Entities;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class CategoryService(IGenericSearchService<Category> searchService) : IGenericSearchService<Category>, ICategoryService
    {
        private IGenericSearchService<Category> _searchService = searchService;

        public async Task<IEnumerable<Category>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) => await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
    }
}
