using eShop.Service.DTO;

namespace eShop.Service.Services.Service
{
    public interface ISubCategoryService
    {
        Task AddAsync(SubCategoryDto subCategoryDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<SubCategoryDto>> GetAllAsync();
        Task<SubCategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<SubCategoryDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm);
        Task UpdateAsync(SubCategoryDto subCategoryDto);
    }
}