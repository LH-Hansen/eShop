using eShop.Repository.IEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class Brand : IHasName
    {
        [Column("brand_id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("FK_product_id")]
        public ICollection<Product>? Products { get; set; }
    }
}
