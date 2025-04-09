using eShop.Service.DTO;

namespace eShop.Service.Services.IService
{
    public interface IReviewService
    {
        Task AddAsync(ReviewDto reviewDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ReviewDto>> GetAllAsync();
        Task<ReviewDto> GetByIdAsync(int id);
        Task<IEnumerable<ReviewDto>> GetByProductIdAsync(int productId);
        Task UpdateAsync(ReviewDto reviewDto);
    }
}