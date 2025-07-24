using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.DTO
{
    public class RegisterEmployeeRequest : RegisterManagerRequest
    {
        [Required]
        public int Age { get; set; }
        public Guid ManagerId { get; set; }
    }
}
