using eShop.Repository.Entities;
using eShop.Service.Services.Generics.IGenericService;

namespace eShop.Service.Services.IService
{
    public interface IProductService : IGenericService<Product>
    {
        Task<IEnumerable<Product>> GetProductsByBrandAsync(int brandId);
    }
}