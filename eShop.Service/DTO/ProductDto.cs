using eShop.Repository.Entities;

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
        public Brand? Brand { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; } = null!;
        public ICollection<Review>? Reviews { get; set; }
    }
}
