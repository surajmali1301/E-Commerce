using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Project_DotNet.Models
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }

        [Required]  
        public string? Role { get; set; }

        //public ICollection<Users> Users { get; set; }
    }
}
