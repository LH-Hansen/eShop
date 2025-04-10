namespace eShop.Service.DTO.Review
{
    public class ReviewUpsertDto
    {
        public required string Title { get; set; }
        public string? Body { get; set; }
        public required int ProductId { get; set; }
    }
}