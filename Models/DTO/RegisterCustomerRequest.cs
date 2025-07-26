using System.ComponentModel.DataAnnotations;

namespace APIPractice.Models.DTO
{
    public class RegisterCustomerRequest : RegisterManagerRequest
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public required string Phone { get; set; }
        [Required]
        public int Age {  get; set; }
        [Required]
        public required string Address { get; set; }
    }
}
