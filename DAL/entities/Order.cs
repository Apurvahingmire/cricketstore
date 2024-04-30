using System;
using System.Collections.Generic;

namespace CricketStore.DAL.entities
{
    public partial class Order
    {
        public Order()
        {
            OderDetails = new HashSet<OderDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OrderStatus { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<OderDetail> OderDetails { get; set; }
    }
}
