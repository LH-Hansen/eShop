using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class Category
    {
        [Column("category_id")]
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        [Column("FK_productcategory_id")]
        public required ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
