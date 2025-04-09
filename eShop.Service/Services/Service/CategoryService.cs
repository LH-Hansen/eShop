using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.Service
{
    public class CategoryService : GenericSearchService<Category>, ICategoryService, IGenericService<Category>
    {
        private readonly IGenericSearchService<Category> _searchService;
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(
            IGenericSearchService<Category> searchService,
            IGenericRepository<Category> repository,
            IMapper mapper) : base(searchService, repository)
        {
            _searchService = searchService;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<CategoryDto>>(await _repository.GetAllAsync());

        public async Task<CategoryDto> GetByIdAsync(int id) =>
            _mapper.Map<CategoryDto>(await _repository.GetByIdAsync(id));

        public async Task<IEnumerable<CategoryDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) =>
            _mapper.Map<IEnumerable<CategoryDto>>(await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm));

        public async Task AddAsync(CategoryDto categoryDto) =>
            await _repository.AddAsync(_mapper.Map<Category>(categoryDto));

        public async Task UpdateAsync(CategoryDto categoryDto) =>
            await _repository.UpdateAsync(_mapper.Map<Category>(categoryDto));

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);

    }
}
