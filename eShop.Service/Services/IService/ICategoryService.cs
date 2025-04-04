using eShop.Repository.Entities;

namespace eShop.Service.Services.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
    }
}