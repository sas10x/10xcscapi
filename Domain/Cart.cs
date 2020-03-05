using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Cart
    {
        public long CartId { get; set; }
        public string ProductName { get; set; }
        public long Quantity { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal Total { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}

