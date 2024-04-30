using System.ComponentModel.DataAnnotations;

namespace CricketStore.BLL.DTOs.Request
{
    public class ProductRequestDTO
    {
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int StockAvailable { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }
    }
}
