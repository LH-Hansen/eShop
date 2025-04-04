using eShop.Repository.Entities;

namespace eShop.Service.Services.IService
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategory>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
    }
}