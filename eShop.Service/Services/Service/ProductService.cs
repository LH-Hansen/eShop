using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;

namespace eShop.Service.Services.Service
{
    public class ProductService(IGenericSearchService<Product> searchService,
                                IGenericRepository<Product> repository,
                                IMapper mapper) : GenericSearchService<Product>(searchService, repository), IProductService, IGenericService<Product>, IProductService
    {
        private readonly IGenericSearchService<Product> _searchService = searchService;
        private readonly IGenericRepository<Product> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<Product> products = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm)
        {
            IEnumerable<Product> products = await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);

            IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productDtos;
        }

        public async Task AddAsync(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            await _repository.AddAsync(product);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);

            await _repository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
