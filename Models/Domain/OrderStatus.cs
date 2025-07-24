using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.Domain
{
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Status { get; set; }
    }
}
