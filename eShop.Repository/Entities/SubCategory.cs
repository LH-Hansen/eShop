using eShop.Repository.IEntity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class SubCategory : IHasName
    {
        [Column("subcategory_id")]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("FK_category_id")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Category("FK_product_id")]
        public ICollection<Product>? Products { get; set; }
    }
}
