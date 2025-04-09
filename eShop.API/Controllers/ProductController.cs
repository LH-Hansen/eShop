using AutoMapper;
using eShop.Service.DTO;
using eShop.Service.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Route("rest/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPaginatedProducts(int page = 1, int pageSize = 10, string searchTerm = "")
        {
            IEnumerable<ProductDto> products = await _productService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            ProductDto product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product data is required.");
            }
            await _productService.AddAsync(productDto);
            return CreatedAtAction(nameof(GetProductById), new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest("Product ID mismatch.");
            }
            await _productService.UpdateAsync(productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
