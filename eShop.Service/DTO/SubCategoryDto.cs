using eShop.Service.DTO.Product;

namespace eShop.Service.DTO
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
    }
}
