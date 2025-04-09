using eShop.Repository.Entities;

namespace eShop.Service.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Body { get; set; }
        public int ProductId { get; set; }
        public required Product Product { get; set; }
    }
}
