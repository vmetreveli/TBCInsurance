using System;
using System.ComponentModel.DataAnnotations;
namespace CleanArchitecture.Domain.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PersonNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        //[Required]
        //public DateTime BirthDate { get; set; }
        [Required]
        public string Sex { get; set; }
    }

}
