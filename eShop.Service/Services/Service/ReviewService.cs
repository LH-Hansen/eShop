using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class ReviewService(IGenericRepository<Review> reviewRepository, IMapper mapper) : IReviewService
    {
        private readonly IGenericRepository<Review> _reviewRepository = reviewRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ReviewDto>> GetAllAsync()
        {
            IEnumerable<Review> reviews = await _reviewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto> GetByIdAsync(int id)
        {
            Review review = await _reviewRepository.GetByIdAsync(id);
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task AddAsync(ReviewDto reviewDto)
        {
            Review review = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.AddAsync(review);
        }

        public async Task UpdateAsync(ReviewDto reviewDto)
        {
            Review review = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.UpdateAsync(review);
        }

        public async Task DeleteAsync(int id)
        {
            await _reviewRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ReviewDto>> GetByProductIdAsync(int productId)
        {
            IEnumerable<Review> reviews = await _reviewRepository.GetAllAsync();
            IEnumerable<Review> filteredReviews = reviews.Where(r => r.ProductId == productId);
            return _mapper.Map<IEnumerable<ReviewDto>>(filteredReviews);
        }
    }
}
