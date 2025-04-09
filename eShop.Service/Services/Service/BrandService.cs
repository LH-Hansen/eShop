using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class BrandService(IGenericSearchService<Brand> searchService,
                        IGenericRepository<Brand> repository,
                        IMapper mapper) : GenericSearchService<Brand>(searchService, repository), IBrandService, IGenericService<Brand>
    {
        private readonly IGenericSearchService<Brand> _searchService = searchService;
        private readonly IGenericRepository<Brand> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<BrandDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<BrandDto>>(await _repository.GetAllAsync());

        public async Task<BrandDto> GetByIdAsync(int id) =>
            _mapper.Map<BrandDto>(await _repository.GetByIdAsync(id));

        public async Task<IEnumerable<BrandDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) =>
            _mapper.Map<IEnumerable<BrandDto>>(await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm));

        public async Task AddAsync(BrandDto brandDto) =>
            await _repository.AddAsync(_mapper.Map<Brand>(brandDto));

        public async Task UpdateAsync(BrandDto brandDto) =>
            await _repository.UpdateAsync(_mapper.Map<Brand>(brandDto));

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
