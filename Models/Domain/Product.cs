using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPractice.Model.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Units { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Threshold { get; set; }
        public string Image_url{ get; set; }
        public bool Is_Active { get; set; }
        //[Required]
        //public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //public Category Category { get; set; }
    }
}
