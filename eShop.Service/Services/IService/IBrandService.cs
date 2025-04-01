using eShop.Repository.Entities;
using eShop.Service.Services.Generics.IGenericService;

namespace eShop.Service.Services.IService
{
    public interface IBrandService : IGenericService<Brand>
    {
        Task<IEnumerable<Brand>> GetPaginatedSearchAsync(int page, int pageSize, string? searchTerm);
    }
}