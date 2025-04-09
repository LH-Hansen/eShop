using eShop.Repository.Entities;

namespace eShop.Service.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int SubCategoryId { get; set; }
        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}
