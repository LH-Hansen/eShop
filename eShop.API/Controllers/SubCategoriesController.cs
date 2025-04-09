using eShop.Service.DTO;
using eShop.Service.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers
{
    [Route("rest/v1/[controller]")]
    [ApiController]
    public class SubCategoriesController(ISubCategoryService subCategoryService) : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService = subCategoryService;

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var subCategories = await _subCategoryService.GetAllAsync();
            return Ok(subCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategoryById(int id)
        {
            var subCategory = await _subCategoryService.GetByIdAsync(id);

            if (subCategory == null)
                return NotFound(new { message = "SubCategory not found." });

            return Ok(subCategory);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetPaginatedSubCategories(int page = 1, int pageSize = 10, string searchTerm = "")
        {
            var subCategories = await _subCategoryService.GetPaginatedSearchAsync(page, pageSize, searchTerm);
            return Ok(subCategories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory([FromBody] SubCategoryDto subCategoryDto)
        {
            if (subCategoryDto == null)
                return BadRequest(new { message = "SubCategory data is null." });

            await _subCategoryService.AddAsync(subCategoryDto);

            return CreatedAtAction(nameof(GetSubCategoryById), new { id = subCategoryDto.Id }, subCategoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubCategory(int id, [FromBody] SubCategoryDto subCategoryDto)
        {
            if (subCategoryDto == null)
                return BadRequest(new { message = "SubCategory data is null." });

            subCategoryDto.Id = id;

            var existingSubCategory = await _subCategoryService.GetByIdAsync(id);
            if (existingSubCategory == null)
                return NotFound(new { message = "SubCategory not found." });

            await _subCategoryService.UpdateAsync(subCategoryDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var existingSubCategory = await _subCategoryService.GetByIdAsync(id);
            if (existingSubCategory == null)
                return NotFound(new { message = "SubCategory not found." });

            await _subCategoryService.DeleteAsync(id);

            return NoContent();
        }
    }
}
