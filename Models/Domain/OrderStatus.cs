using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.Domain
{
    [Index(nameof(Name), IsUnique = true)]
    public class OrderStatus
    {
        [Key]
        public Guid Id { get; set; }

        public required string Name { get; set; }


        //// Reverse Navigation Properties
        //public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
