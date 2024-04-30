namespace CricketStore.BLL.DTOs.Request
{
    public class CartDetailRequestDTO
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
