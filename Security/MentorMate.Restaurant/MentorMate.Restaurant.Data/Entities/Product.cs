﻿using System.ComponentModel.DataAnnotations;

namespace MentorMate.Restaurant.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
