using eShop.Service.DTO.Product;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.IService
{
    public interface IProductService : IGenericDtoSearchService<ProductDto>
    {
        Task<IEnumerable<ProductDto>> GetProductsByBrandAsync(int brandId);
    }
}