using System;
using System.ComponentModel.DataAnnotations;
namespace CleanArchitecture.Domain.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public Company Company { get; set; }
        public Market Market { get; set; }
        public DateTime Time { get; set; } =DateTime.Now;
        public decimal CompanyPrice { get; set; }
    }
}