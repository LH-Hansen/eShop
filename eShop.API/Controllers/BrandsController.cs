using eShop.Service.DTO;
using eShop.Service.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Route("rest/v1/[controller]")]
    [ApiController]
    public class BrandsController(IBrandService brandService) : ControllerBase
    {
        private readonly IBrandService _brandService = brandService;

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetPaginatedBrands(int page = 1, int pageSize = 10, string searchTerm = "")
        {
            IEnumerable<BrandDTO> brands = await _brandService.GetPaginatedSearchAsync(page, pageSize, searchTerm);

            return Ok(brands);
        }

        //[HttpGet("id")]
        //public async Task<IActionResult> GetBrandById(int id)
        //{
        //    brand = await _brandService.GetByIdAsync(id);

        //    return Ok(brand);
        //}

    }
}