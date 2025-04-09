namespace eShop.Service.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required double Price { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; } = 0;
        public int BrandId { get; set; }
        public BrandDto? Brand { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategoryDto SubCategory { get; set; } = null!;
        public ICollection<ReviewDto>? Reviews { get; set; }
    }
}
