using System;

namespace Application.Discounts
{
    public class DiscountDto
    {
        public long DiscountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Pursinto { get; set; }
        public string VarGrade { get; set; }
    }
}