using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
