﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorMate.Restaurant.Data.Entities
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        public string? WaiterId { get; set; }
        public User? Waiter { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public decimal Bill => Orders.Select(o => o.TotalPrice).Sum();
        public bool IsOccupied { get; set; } = false;
    }
}
