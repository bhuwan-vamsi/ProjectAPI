using APIPractice.Models.Domain;

namespace APIPractice.Models.DTO
{
    public class PurchaseOrderRequest
    {
        public OrderStatus? OrderStatus { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
