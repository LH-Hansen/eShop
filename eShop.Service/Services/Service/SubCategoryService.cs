using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.Service
{
    public class SubCategoryService(IGenericSearchService<SubCategory> searchService,
                                    IGenericRepository<SubCategory> repository,
                                    IMapper mapper) : GenericSearchService<SubCategory>(searchService, repository), ISubCategoryService, IGenericService<SubCategory>
    {
        private readonly IGenericSearchService<SubCategory> _searchService = searchService;
        private readonly IGenericRepository<SubCategory> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<SubCategoryDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<SubCategoryDto>>(await _repository.GetAllAsync());

        public async Task<SubCategoryDto> GetByIdAsync(int id) =>
            _mapper.Map<SubCategoryDto>(await _repository.GetByIdAsync(id));

        public async Task<IEnumerable<SubCategoryDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) =>
            _mapper.Map<IEnumerable<SubCategoryDto>>(await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm));

        public async Task AddAsync(SubCategoryDto subCategoryDto) =>
            await _repository.AddAsync(_mapper.Map<SubCategory>(subCategoryDto));

        public async Task UpdateAsync(SubCategoryDto subCategoryDto) =>
            await _repository.UpdateAsync(_mapper.Map<SubCategory>(subCategoryDto));

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
