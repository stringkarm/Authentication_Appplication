using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication_Appplication.Model
{
    public class HeelInfo
    {
        [Key]
        public int VariantId { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        [Range(4, 12)]
        public double Size { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 5000.00)]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

    }
}
