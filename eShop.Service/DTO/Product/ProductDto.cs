using eShop.Service.DTO.Review;

namespace eShop.Service.DTO.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public double Price { get; set; } = 0;
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; } = 0;
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public ICollection<ReviewDto>? Reviews { get; set; }
    }
}
