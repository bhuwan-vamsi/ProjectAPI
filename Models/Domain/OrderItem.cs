using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPractice.Models.Domain
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public required int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public required Product Product { get; set; }
        public required Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public required Order Order { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
    }
}
