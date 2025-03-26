using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class Order
    {
        [Column("order_id")]
        public int Id { get; set; }

        [Column("orderdate")]
        public DateTime OrderDate { get; set; }

        public double TotalAmount { get; set; }

        //[Column("FK_orderline)id")]
        public ICollection<OrderLine>? OrderLine { get; set; }

    }
}
