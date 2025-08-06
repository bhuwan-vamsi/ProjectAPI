using APIPractice.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.DTO
{
    public class UpdateProductDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public required string Name { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(1, double.MaxValue)]
        public decimal CostPrice { get; set; }
        [Required]
        [StringLength(15, MinimumLength =2)]
        public required string Units { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Threshold { get; set; }
        public required string ProductStatus { get; set; }
        public string? ImageUrl { get; set; }
        public required Category Category { get; set; }

    }
}
