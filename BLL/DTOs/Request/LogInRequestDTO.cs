namespace CricketStore.BLL.DTOs.Request
{
    public class LogInRequestDTO
    {
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
