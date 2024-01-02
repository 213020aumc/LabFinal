using System;
using System.Collections.Generic;

namespace Q2_Part2.Models
{
    public partial class ProductInfo
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
