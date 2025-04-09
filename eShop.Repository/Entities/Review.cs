using System.ComponentModel.DataAnnotations.Schema;

namespace eShop.Repository.Entities
{
    public class Review
    {
        [Column("review_id")]
        public int Id { get; set; }

        [Column("title")]
        public required string Title { get; set; }
        [Column("body")]
        public string? Body { get; set; }

        [Column("FK_product_id")]
        public required int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
