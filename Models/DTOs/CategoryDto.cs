using System.ComponentModel.DataAnnotations;

namespace APIPractice.Model.DTO
{
    public class CategoryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
