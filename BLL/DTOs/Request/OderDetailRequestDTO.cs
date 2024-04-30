using System.ComponentModel.DataAnnotations;

namespace CricketStore.BLL.DTOs.Request
{
    public class OderDetailRequestDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
