namespace APIPractice.Models.DTO
{
    public class OrderDto
    {
        public IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
