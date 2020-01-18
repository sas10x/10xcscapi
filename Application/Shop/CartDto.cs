using System;

namespace Application.Shop
{
    public class CartDto
    {
        public long CartId { get; set; }
        public long Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public long Product { get; set; }
        public Guid Order { get; set; }
        public string ProductName { get; set; }
       
    }
}