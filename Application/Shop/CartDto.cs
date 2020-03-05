using System;

namespace Application.Shop
{
    public class CartDto
    {
        public long CartId { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public long Product { get; set; }
        public Guid Order { get; set; }
        public string ProductName { get; set; }
       
    }
}