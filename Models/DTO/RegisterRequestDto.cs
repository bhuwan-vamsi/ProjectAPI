using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public required string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        [Required]
        public required string Role { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public string? Address { get; set; }
    }
}
