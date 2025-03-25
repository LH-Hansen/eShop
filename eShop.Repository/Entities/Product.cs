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


        [Column("brand_id")]
        public required Brand Brand { get; set; }

        [Column("FK_productcategory_id")]
        public required ICollection<ProductCategory> ProductCategory { get; set; }

    }
}
