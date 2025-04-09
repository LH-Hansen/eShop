using eShop.Service.DTO;

namespace eShop.Service.Services.Service
{
    public interface IProductService
    {
        Task AddAsync(ProductDto productDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
        Task UpdateAsync(ProductDto productDto);
    }
}