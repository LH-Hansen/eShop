using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class CategoryProduct
    {
        [Column("FK_category_id")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Column("FK_product_id")]
        public int ProductId { get; set; }
    }
}
