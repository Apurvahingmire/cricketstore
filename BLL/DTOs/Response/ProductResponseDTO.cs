namespace CricketStore.BLL.DTOs.Response
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int StockAvailable { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
    }
}
