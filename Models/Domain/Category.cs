using APIPractice.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace practice_project.Models.Domain
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        public required string Name { get; set; }


        // Reverse Navigation Properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
