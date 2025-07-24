using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.DTO
{
    public class CategoryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
