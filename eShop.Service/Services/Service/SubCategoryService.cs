using eShop.Repository.Entities;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class SubCategoryService(IGenericSearchService<SubCategory> searchService) : IGenericSearchService<SubCategory>, ISubCategoryService
    {
        private readonly IGenericSearchService<SubCategory> _searchService;

        public async Task<IEnumerable<SubCategory>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) => await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
    }
}
