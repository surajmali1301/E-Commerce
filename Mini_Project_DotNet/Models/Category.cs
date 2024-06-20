﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Project_DotNet.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]

        public int CategoryId { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
