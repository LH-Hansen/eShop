using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class Product
    {
        [Column("product_id")]
        public int Id { get; set; }

        public double Price { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required int Stock { get; set; }


        [Column("FK_brand_id")]
        public int BrandId { get; set; }
        public required Brand Brand { get; set; }

        [Column("FK_categoryproduct_id")]
        public ICollection<CategoryProduct>? CategoryProducts { get; set; } = null!;

        public ICollection<Category> Categories { get; set; } = null!;

    }
}
