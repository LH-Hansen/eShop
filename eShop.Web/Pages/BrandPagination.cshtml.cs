using eShop.Repository.Entities;
using eShop.Service.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eShop.Web.Pages
{
    public class BrandPaginationModel(IBrandService brandService) : PageModel
    {
        private readonly IBrandService _brandService = brandService;
        private const int PageSize = 10;

        public IEnumerable<Brand>? Brands { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public new int Page { get; set; } = 1;

        public async Task OnGetAsync()
        {
            int totalCount = await _brandService.GetCountAsync();

            TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);

            if (Page < 1) Page = 1;
            if (Page > TotalPages) Page = TotalPages;

            Brands = await _brandService.GetPaginatedAsync(Page, PageSize);
            CurrentPage = Page;
        }
    }
}
