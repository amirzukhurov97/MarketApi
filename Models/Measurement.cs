﻿using MarketApi.Models.Abstract;

namespace MarketApi.Models
{
    public class Measurement : EntityBase
    {
        public string? Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();  

    }
}