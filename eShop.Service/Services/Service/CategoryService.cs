using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.Service
{
    public class CategoryService : GenericSearchService<Category>, ICategoryService, IGenericService<Category>, ICategoryService
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

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<Category> categories = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm)
        {
            IEnumerable<Category> categories = await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task AddAsync(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            await _repository.AddAsync(category);
        }

        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            await _repository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
