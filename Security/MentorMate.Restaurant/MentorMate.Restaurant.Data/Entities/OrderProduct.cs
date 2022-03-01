﻿namespace MentorMate.Restaurant.Data.Entities
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }

    }
}
