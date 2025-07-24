using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPractice.Models.Domain
{
    public class Employee
    {
        [Key]
        public required string Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Guid ManagerId { get; set; } 
        public bool IsActive { get; set; }
    }
}
