using eShop.Repository.Entities;
using eShop.Service.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.Web.Pages
{
    public class BrandSearchModel : PageModel
    {
        private readonly IBrandService _brandService;

        public BrandSearchModel(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IEnumerable<Brand> Brands { get; set; }

        public async Task OnGetAsync()
        {
            Brands = await _brandService.GetPaginatedSearchAsync(1, 100, SearchTerm);
            Brands = Brands.OrderBy(b => b.Name);
        }
    }
}
