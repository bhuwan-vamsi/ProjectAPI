using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.DTO
{
    public class OrderItemDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public decimal? UnitPrice { get; set; }
    }
}
