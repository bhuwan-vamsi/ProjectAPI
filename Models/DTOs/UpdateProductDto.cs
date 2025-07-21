using System.ComponentModel.DataAnnotations;

namespace APIPractice.Model.DTO
{
    public class UpdateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Units { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Threshold { get; set; }
        public string Image_url { get; set; }
    }
}
