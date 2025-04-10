using AutoMapper;
using eShop.Repository.Entities;
using eShop.Service.DTO.Product;
using eShop.Service.Services.Generics.IGeneric;
using eShop.Service.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Route("rest/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericDtoService<Product, ProductDto, ProductUpsertDto> _genericService;
        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public ProductsController(IGenericDtoService<Product, ProductDto, ProductUpsertDto> genericService, IProductService productService, IMapper mapper)
        {
            _genericService = genericService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            IEnumerable<ProductDto> products = await _genericService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("search/{ProductName}")]
        public async Task<IActionResult> GetPaginatedProducts(string ProductName)
        {
            IEnumerable<ProductDto> products = await _productService.GetPaginatedSearchAsync(1, 10, ProductName);
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            ProductDto product = await _genericService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddProduct([FromBody] ProductUpsertDto productDto)
        {
            if (productDto == null)
                return BadRequest("Product data is required.");

            await _genericService.AddAsync(productDto);
            return CreatedAtAction(nameof(AddProduct), productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpsertDto productDto)
        {
            await _genericService.UpdateAsync(productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _genericService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("brand/{brandId}")]
        public async Task<IEnumerable<ProductUpsertDto>> GetByBrandIdAsync(int brandId) =>
            _mapper.Map<IEnumerable<ProductUpsertDto>>((await _productService.GetProductsByBrandAsync(brandId)));
    }
}
