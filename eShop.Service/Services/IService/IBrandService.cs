using eShop.Repository.Entities;
using eShop.Service.DTO;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.IService
{
    public interface IBrandService : IGenericSearchService<Brand>, IGenericService<Brand>
    {
        Task<IEnumerable<BrandDTO>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
    }
}