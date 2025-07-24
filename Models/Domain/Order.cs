using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APIPractice.Models.Domain
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public required string CustomerId { get; set; }
        [AllowNull]
        public string? EmployeeId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public required int OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public required OrderStatus OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeliveredAt { get; set; }
        [ForeignKey("CustomerId")]
        public required Customer Customer { get; set; }
        [ForeignKey("EmployeeId")]
        public Customer? Employee { get; set; }
    }
}
