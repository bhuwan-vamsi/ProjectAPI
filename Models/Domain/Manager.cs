using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.Domain
{
    public class Manager
    {
        [Key]
        public required string Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
