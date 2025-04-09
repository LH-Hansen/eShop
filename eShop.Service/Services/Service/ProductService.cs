using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;
using Microsoft.Extensions.Caching.Memory;

namespace eShop.Service.Services.Service
{
    public class ProductService(IGenericSearchService<Product> searchService,
                                IGenericRepository<Product> repository,
                                IMapper mapper,
                                IMemoryCache cache) : GenericSearchService<Product>(searchService, repository), IProductService, IGenericService<Product>
    {
        private readonly IGenericSearchService<Product> _searchService = searchService;
        private readonly IGenericRepository<Product> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IMemoryCache _cache = cache;

        public async Task<IEnumerable<ProductDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<ProductDto>>(
               await _cache.GetOrCreateAsync("all_products", async entry =>
               {
                   entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                   return await _repository.GetAllAsync();
               })
            );

        public async Task<ProductDto> GetByIdAsync(int id) =>
            _mapper.Map<ProductDto>(
                await _cache.GetOrCreateAsync($"product_{id}", async entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                    return await _repository.GetByIdAsync(id);
                })
            );

        public async Task<IEnumerable<ProductDto>> GetPaginatedSearchAsync(int page, int pageSize, string searchTerm) =>
             _mapper.Map<IEnumerable<ProductDto>>(
                 await _cache.GetOrCreateAsync($"paginated_products_{page}_{pageSize}_{searchTerm}", async entry =>
                 {
                     entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                     return await _searchService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
                 })
             );

        public async Task AddAsync(ProductDto productDto) =>
            await _repository.AddAsync(_mapper.Map<Product>(productDto)).ContinueWith(_ => _cache.Remove("all_products"));

        public async Task UpdateAsync(ProductDto productDto) =>
            await _repository.UpdateAsync(_mapper.Map<Product>(productDto)).ContinueWith(_ => _cache.Remove("all_products"));


        public async Task DeleteAsync(int id) =>
            await _repository.DeleteAsync(id).ContinueWith(_ => _cache.Remove("all_products"));


        public async Task<IEnumerable<ProductDto>> GetProductsByBrandAsync(string brand)
        {
            IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<ProductDto>>((await _repository.GetAllAsync()).Where(p => p.Brand.Name == brand));

            _cache.Remove("all_products");

            return productDtos;
        }
    }
}
