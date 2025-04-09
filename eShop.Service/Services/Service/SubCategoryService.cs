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

        public async Task<IEnumerable<SubCategoryDto>> GetAllAsync()
        {
            IEnumerable<SubCategory> subCategories = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
        }

        public async Task<SubCategoryDto> GetByIdAsync(int id)
        {
            SubCategory subCategory = await _repository.GetByIdAsync(id);

            return _mapper.Map<SubCategoryDto>(subCategory);
        }

        public async Task<IEnumerable<SubCategoryDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm)
        {
            IEnumerable<SubCategory> subCategories = await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);

            IEnumerable<SubCategoryDto> subCategoryDtos = _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);

            return subCategoryDtos;
        }

        public async Task AddAsync(SubCategoryDto subCategoryDto)
        {
            SubCategory subCategory = _mapper.Map<SubCategory>(subCategoryDto);

            await _repository.AddAsync(subCategory);
        }

        public async Task UpdateAsync(SubCategoryDto subCategoryDto)
        {
            SubCategory subCategory = _mapper.Map<SubCategory>(subCategoryDto);

            await _repository.UpdateAsync(subCategory);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
