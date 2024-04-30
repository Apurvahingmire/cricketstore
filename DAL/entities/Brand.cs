using System;
using System.Collections.Generic;

namespace CricketStore.DAL.entities
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        

        public virtual ICollection<Product> Products { get; set; }
    }
}
