using System;
using System.Collections.Generic;

#nullable disable

namespace MVCDemo_Complete.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public byte[] Picture { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
