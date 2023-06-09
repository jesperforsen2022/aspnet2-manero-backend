﻿using Backend.Interfaces;

namespace Backend.Models
{
    public class Product : IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public string? Description { get; set; }
        public float? RatingStar { get; set; }
        public List<string>? Review { get; set; } = new List<string>();
        public string? ImageName { get; set; } = null!;
        public string? Color { get; set; }
        public string? Gender { get; set; }
        public List<string> Size { get; set; } = new List<string>();
        public List<string> Tags { get; set; } = new List<string>();
    }
}
