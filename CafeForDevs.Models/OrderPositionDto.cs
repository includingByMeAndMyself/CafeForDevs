﻿namespace CafeForDevs.Models
{

    public class OrderPositionDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Sum => Price * Quantity;
    }
}
