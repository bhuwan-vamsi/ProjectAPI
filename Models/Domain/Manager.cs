using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.Domain
{
    public class Manager
    {
        [Key]
        public Guid Id { get; set; } // This Id will be extracted from Identity User

        public required string Name { get; set; }


        // Reverse Navigation Properties
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        // public ICollection<StockUpdateHistory> StocksHistory { get; set; } = new List<StockUpdateHistory>();
    }
}
