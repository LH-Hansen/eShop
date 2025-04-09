using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class SubCategoryService : GenericSearchService<SubCategory>, ISubCategoryService, IGenericSearchService<SubCategory>
    {
        private readonly IGenericSearchService<SubCategory> _searchService;

        public SubCategoryService(IGenericSearchService<SubCategory> searchService, IGenericRepository<SubCategory> repository) : base(searchService, repository)
        {
            _searchService = searchService;
        }

        public async Task<IEnumerable<SubCategory>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) => await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
    }
}
