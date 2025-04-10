// Ignore Spelling: DTO

using eShop.Service.DTO.Product;

namespace eShop.Service.DTO
{
    public class BrandDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<ProductDto>? Products { get; set; }
    }
}
