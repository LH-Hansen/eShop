using eShop.Service.DTO;

namespace eShop.Service.Services.IService
{
    public interface IBrandService
    {
        Task AddAsync(BrandDto brandDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<BrandDto>> GetAllAsync();
        Task<BrandDto> GetByIdAsync(int id);
        Task<IEnumerable<BrandDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
        Task UpdateAsync(BrandDto brandDto);
    }
}