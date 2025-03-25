using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class Category
    {
        [Column("category_id")]
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        [Column("FK_categoryproduct_id")]
        public ICollection<CategoryProduct> CategoryProducts { get; set; } = [];

        public ICollection<Product> Products { get; set; }
    }
}