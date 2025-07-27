using APIPractice.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPractice.Models.DTO
{
    public class OrderHistoryDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public decimal Amount { get; set; }

        public required OrderStatus OrderStatus { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
