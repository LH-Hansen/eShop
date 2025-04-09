using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class CategoryService : GenericSearchService<Category>, ICategoryService, IGenericSearchService<Category>
    {
        private readonly IGenericSearchService<Category> _searchService;

        public CategoryService(IGenericSearchService<Category> searchService, IGenericRepository<Category> repository) : base(searchService, repository)
        {
            _searchService = searchService;
        }

        public async Task<IEnumerable<Category>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) => await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
    }
}
