namespace eShop.Web.Models
{
    public class ProductCreateRequest
    {
        public double Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
