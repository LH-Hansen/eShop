using eShop.Repository.Entities;

namespace eShop.Service.DTO
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
