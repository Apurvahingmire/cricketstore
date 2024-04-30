namespace CricketStore.BLL.DTOs.Response
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string PhoneNo { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
