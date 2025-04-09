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

        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            IEnumerable<Brand> brands = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<BrandDto>>(brands);
        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {
            Brand brand = await _repository.GetByIdAsync(id);

            return _mapper.Map<BrandDto>(brand);
        }

        public async Task<IEnumerable<BrandDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm)
        {
            IEnumerable<Brand> brands = await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);

            IEnumerable<BrandDto> brandDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);

            return brandDtos;
        }

        public async Task AddAsync(BrandDto brandDto)
        {
            Brand brand = _mapper.Map<Brand>(brandDto);

            await _repository.AddAsync(brand);
        }

        public async Task UpdateAsync(BrandDto brandDto)
        {
            Brand brand = _mapper.Map<Brand>(brandDto);

            await _repository.UpdateAsync(brand);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
