using System.ComponentModel.DataAnnotations;

namespace CricketStore.BLL.DTOs.Request
{
    public class UserRequestDTO
    {
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
