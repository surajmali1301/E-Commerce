using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Project_DotNet.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UserId { get; set; }

        public string? Image {  get; set; }

        public decimal Price {  get; set; }

        [Required]
        public int Quantity { get; set; }

        [NotMapped]
        public Product Products { get; set; }
    }
}
