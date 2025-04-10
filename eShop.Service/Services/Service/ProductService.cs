using AutoMapper;
using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.DTO.Product;
using eShop.Service.Services.Generics.Generic;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;
using Microsoft.Extensions.Caching.Memory;

namespace eShop.Service.Services.Service
{
    public class ProductService(
        IGenericSearchService<Product> searchService,
        IGenericRepository<Product> repository,
        IMapper mapper,
        IMemoryCache cache
    ) : GenericDtoSearchService<Product, ProductDto, ProductUpsertDto>(searchService, repository, mapper, cache), IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetProductsByBrandAsync(int brandId)
        {
            var products = await _repository.GetAllAsync(p => p.Brand);

            var filtered = products.Where(p => p.Brand.Id == brandId);

            _cache.Remove("all_products");

            return _mapper.Map<IEnumerable<ProductDto>>(filtered);
        }
    }
}