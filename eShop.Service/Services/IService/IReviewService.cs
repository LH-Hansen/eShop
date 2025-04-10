using eShop.Service.DTO.Review;

namespace eShop.Service.Services.IService
{
    public interface IReviewService
    {
        Task AddAsync(ReviewUpsertDto reviewDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ReviewDto>> GetAllAsync();
        Task<ReviewDto> GetByIdAsync(int id);
        Task<IEnumerable<ReviewDto>> GetByProductIdAsync(int productId);
        Task UpdateAsync(ReviewUpsertDto reviewDto);
    }
}