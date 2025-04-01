using eShop.Repository.IEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class Product : IHasName
    {
        [Column("product_id")]
        public int Id { get; set; }

        [Column("price")]
        public required double Price { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("stock")]
        public int Stock { get; set; } = 0;


        [Column("FK_brand_id")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        [Column("FK_subcategory_id")]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; } = null!;

        public ICollection<Review>? Reviews { get; set; }

    }
}
