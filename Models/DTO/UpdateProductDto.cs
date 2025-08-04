using APIPractice.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.DTO
{
    public class UpdateProductDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        [Required]
        public required string Units { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Threshold { get; set; }
        public required string ProductStatus { get; set; }
        public string? ImageUrl { get; set; }
        public required Category Category { get; set; }

    }
}
