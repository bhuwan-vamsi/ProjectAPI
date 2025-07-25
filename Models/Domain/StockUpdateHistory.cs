using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practice_project.Models.Domain
{
    public class StockUpdateHistory
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid ManagerId { get; set; }

        public int Quantity { get; set; }

        public DateTime TimeStamp { get; set; }


        // Navigation Properties
        [ForeignKey(nameof(ProductId))]
        public required Product Product { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public required Manager Manager { get; set; }
    }
}
