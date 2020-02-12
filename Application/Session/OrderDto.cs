using System;
using System.Collections.Generic;
using Domain;

namespace Application.Session
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public DateTime Date{ get; set; }
        public decimal Amount { get; set; }
    }
}