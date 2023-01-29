using System.ComponentModel.DataAnnotations;
namespace Quotation.Models
{
    public class QuotationModel
    {
        [Required(ErrorMessage = "Please enter a sale price.")]
        [Range(0.1,9999999.0, ErrorMessage = "Subtotal Must be 0.1 or more.")]
        public decimal? SubTotal { get; set; }

        [Required(ErrorMessage = "Please enter a discount percent.")]
        [Range(1, 100, ErrorMessage = "Discount must be between 1 and 100.")]
        public decimal? Discount { get; set; }
        public decimal DiscountAmount() => SubTotal > 0 ? (decimal) ((SubTotal / 100) * Discount) : 0;
        public decimal FinalTotal() => ((decimal) (SubTotal - (DiscountAmount())));
    }
}
