﻿using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO.Review;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class ReviewService(IGenericRepository<Review> reviewRepository, IMapper mapper) : IReviewService
    {
        private readonly IGenericRepository<Review> _reviewRepository = reviewRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ReviewDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<ReviewDto>>(await _reviewRepository.GetAllAsync(r => r.Product));

        public async Task<ReviewDto> GetByIdAsync(int id) =>
            _mapper.Map<ReviewDto>(await _reviewRepository.GetByIdAsync(id, r => r.Product));


        public async Task AddAsync(ReviewUpsertDto reviewDto) =>
            await _reviewRepository.AddAsync(_mapper.Map<Review>(reviewDto));

        public async Task UpdateAsync(ReviewUpsertDto reviewDto) =>
            await _reviewRepository.UpdateAsync(_mapper.Map<Review>(reviewDto));

        public async Task DeleteAsync(int id) =>
            await _reviewRepository.DeleteAsync(id);

        public async Task<IEnumerable<ReviewDto>> GetByProductIdAsync(int productId) =>
            _mapper.Map<IEnumerable<ReviewDto>>((await _reviewRepository.GetAllAsync(r => r.Product)).Where(r => r.ProductId == productId));
    }
}
