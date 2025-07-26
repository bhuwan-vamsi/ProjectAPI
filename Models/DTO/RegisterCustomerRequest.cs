using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.DTO
{
    public class RegisterCustomerRequest : RegisterManagerRequest
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public required string Phone { get; set; }
    }
}
