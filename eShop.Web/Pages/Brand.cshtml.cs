using eShop.Repository.Entities;
using eShop.Service.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.Web.Pages
{
    public class BrandModel(IBrandService brandService) : PageModel
    {
        private readonly IBrandService _brandService = brandService;

        public required IEnumerable<Brand> Brands { get; set; }


        [BindProperty]
        public required Brand Brand { get; set; }

        public string? Message { get; set; }


        public async Task OnGetAsync()
        {
            Brands = await _brandService.GetAllAsync();
        }


        public async Task<IActionResult> OnPostCreateAsync()
        {
            try
            {
                await _brandService.AddAsync(Brand);
                Message = "Brand created successfully!";

                Brands = await _brandService.GetAllAsync();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the brand.");
            }

            await LoadBrands();

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (Brand.Id != 0)
            {
                try
                {
                    await _brandService.UpdateAsync(Brand);
                    Message = "Brand updated successfully!";
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the brand.");
                }
            }

            await LoadBrands();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int brandId)
        {
            if (brandId != 0)
            {
                try
                {
                    await _brandService.DeleteAsync(brandId);
                    Message = "Brand deleted successfully!";
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while deleting the brand.");
                }
            }

            await LoadBrands();

            return Page();
        }

        private async Task LoadBrands()
        {
            Brands = await _brandService.GetAllAsync();
        }
    }
}
