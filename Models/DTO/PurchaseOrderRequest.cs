using APIPractice.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.DTO
{
    public class PurchaseOrderRequest
    {
        [Required]
        public required IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
