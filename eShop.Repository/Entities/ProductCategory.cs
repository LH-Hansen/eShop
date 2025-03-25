using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class ProductCategory
    {
        [Column("FK_product_id")]
        public int ProductId { get; set; }
        public required Product Product { get; set; }


        [Column("FK_category_id")]
        public int CategoryId { get; set; }
        public required Category Category { get; set; }
    }
}
