using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;
using MarketApi.Models.Abstract;

namespace MarketApi.Models
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public double Capacity { get; set; } 
        public string Description { get; set; }

    }
}
