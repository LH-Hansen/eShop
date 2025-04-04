using eShop.Repository.Entities;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.IService
{
    public interface IProductService : IGenericSearchService<Product>
    {
        Task<IEnumerable<Product>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
    }
}