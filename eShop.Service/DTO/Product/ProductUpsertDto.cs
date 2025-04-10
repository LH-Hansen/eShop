namespace eShop.Service.DTO.Product
{
    public class ProductUpsertDto
    {
        public double Price { get; set; } = 0;
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; } = 0;

        public required int SubCategoryId { get; set; }
        public required int BrandId { get; set; }
    }
}
