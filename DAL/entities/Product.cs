using System;
using System.Collections.Generic;

namespace CricketStore.DAL.entities
{
    public partial class Product
    {
        public Product()
        {
            CartDetails = new HashSet<CartDetail>();
            OderDetails = new HashSet<OderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int StockAvailable { get; set; }
        public string? ImageUrl { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<OderDetail> OderDetails { get; set; }
    }
}
