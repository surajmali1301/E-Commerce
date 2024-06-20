using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Project_DotNet.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]

        public string? Image {  get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set;}

        public int CategoryId { get; set;}

        public Category Category { get; set; }
    }
}
