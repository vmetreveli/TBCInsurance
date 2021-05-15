using System;
using System.ComponentModel.DataAnnotations;
namespace CleanArchitecture.Domain.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        public string CompanyName { get; set; }
        public Market Market { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;

    }
}