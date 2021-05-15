using System;
using System.ComponentModel.DataAnnotations;
namespace CleanArchitecture.Domain.Models
{
    public class Market
    {
        [Key]
        public int Id { get; set; }
        public string MarketName { get; set; }
        public decimal Price { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}