using eShop.Repository.Entities;
using eShop.Repository.Repositories.Generics.Interface;
using eShop.Service.Services.Generics.GenericSerivice;
using eShop.Service.Services.IService;

namespace eShop.Service.Services.Service
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
            : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsByBrandAsync(int brandId)
        {
            return await Task.FromResult(_productRepository
                                         .GetAllAsync()
                                         .Result
                                         .Where(p => p.BrandId == brandId));
        }
    }
}
