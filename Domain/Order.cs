using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime Date{ get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal Amount { get; set; }
        public virtual Address Address { get; set; }
        

        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}