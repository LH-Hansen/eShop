using eShop.Service.DTO.Product;

namespace eShop.Service.Services.Service
{
    public interface IProductService
    {
        Task AddAsync(ProductUpsertDto productDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
        Task UpdateAsync(ProductUpsertDto productDto);
        Task<IEnumerable<ProductUpsertDto>> GetProductsByBrandAsync(int id);


    }
}