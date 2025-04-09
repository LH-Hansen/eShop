using eShop.Service.DTO;

namespace eShop.Service.Services.Service
{
    public interface ICategoryService
    {
        Task AddAsync(CategoryDto categoryDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<CategoryDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
        Task UpdateAsync(CategoryDto categoryDto);
    }
}