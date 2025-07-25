using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practice_project.Models.Domain
{
    [Index(nameof(OrderId), IsUnique = true)]
    public class TaskHistory
    {
        [Key]
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid EmployeeId { get; set; }

        public DateTime AcceptedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }


        // Navigation Properties
        [ForeignKey(nameof(OrderId))]
        public required Order Order { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public required Employee Employee { get; set; }
    }
}
