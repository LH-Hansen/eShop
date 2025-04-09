using System.Threading.Tasks;
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
                                IMapper mapper) : GenericSearchService<Product>(searchService, repository), IProductService, IGenericService<Product>
    {
        private readonly IGenericSearchService<Product> _searchService = searchService;
        private readonly IGenericRepository<Product> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ProductDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<ProductDto>>(await _repository.GetAllAsync());

        public async Task<ProductDto> GetByIdAsync(int id) =>
            _mapper.Map<ProductDto>(await _repository.GetByIdAsync(id));

        public async Task<IEnumerable<ProductDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) =>
            _mapper.Map<IEnumerable<ProductDto>>(await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm));

        public async Task AddAsync(ProductDto productDto) =>
            await _repository.AddAsync(_mapper.Map<Product>(productDto));

        public async Task UpdateAsync(ProductDto productDto) =>
            await _repository.UpdateAsync(_mapper.Map<Product>(productDto));

        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id);

        public async Task<IEnumerable<ProductDto>> GetProductsByBrandAsync(string brand) =>
            _mapper.Map<IEnumerable<ProductDto>>((await _repository.GetAllAsync()).Where(p => p.Brand.Name == brand));

    }
}
