using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal BasePrice { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal Price { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual VarGrade VarGrade { get; set; }
        public virtual VarDiameter VarDiameter { get; set; }
        public virtual VarLength VarLength { get; set; }
    }
}