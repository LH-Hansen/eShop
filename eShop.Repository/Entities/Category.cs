using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class Category
    {
        [Column("category_id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("FK_subcategory_id")]
        public int SubCategoryId { get; set; }
        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}