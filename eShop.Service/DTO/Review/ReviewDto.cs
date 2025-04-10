namespace eShop.Service.DTO.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Body { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
