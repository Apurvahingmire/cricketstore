using System;
using System.Collections.Generic;

namespace CricketStore.DAL.entities
{
    public partial class User
    {
        public User()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

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

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
