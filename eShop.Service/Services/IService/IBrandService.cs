using eShop.Repository.Entities;

namespace eShop.Service.Services.Service
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
    }
}