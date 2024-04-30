using System.ComponentModel.DataAnnotations;

namespace CricketStore.BLL.DTOs.Request
{
    public class OrderRequestDTO
    {

        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OrderStatus { get; set; }
    }
    
}
