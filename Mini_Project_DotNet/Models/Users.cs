using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Project_DotNet.Models
{
    [Table("Users")]
    public class Users
    {
      

        [Key]
        public int UserId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public int Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public int ConfirmPassword { get; set; }

        [Required]
        public int RoleId { get; set; }

        //public Roles Roles {  get; set; }
    }
}
