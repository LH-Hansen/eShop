using AutoMapper;
using eShop.Service.DTO;
using eShop.Service.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Route("rest/v1/[controller]")]
    [ApiController]
    public class BrandsController(IBrandService brandService, IMapper mapper) : ControllerBase
    {
        private readonly IBrandService _brandService = brandService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPaginatedBrands(int page = 1, int pageSize = 10, string searchTerm = "")
        {
            IEnumerable<BrandDto> brands = await _brandService.GetPaginatedSearchAsync(page, pageSize, searchTerm);

            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            BrandDto brands = await _brandService.GetByIdAsync(id);

            return Ok(brands);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBrand([FromBody] BrandDto brandDto)
        {
            if (brandDto == null)
            {
                return BadRequest("Brand data is required.");
            }
            await _brandService.AddAsync(brandDto);
            return CreatedAtAction(nameof(GetBrandById), new { id = brandDto.Id }, brandDto);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBrand(int id, [FromBody] BrandDto brandDto)
        {
            if (id != brandDto.Id)
            {
                return BadRequest("Brand ID mismatch.");
            }
            await _brandService.UpdateAsync(brandDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.DeleteAsync(id);
            return NoContent();
        }
    }
}