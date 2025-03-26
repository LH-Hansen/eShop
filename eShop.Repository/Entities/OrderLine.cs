using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class OrderLine
    {
        [Column("oder_id")]
        public int Id { get; set; }

        [Column("FK_order_id")]
        public int OrderId { get; set; }
        public required Order Order { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        public required Product Product { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("total")]
        public double Total => Quantity * Price;
    }
}
