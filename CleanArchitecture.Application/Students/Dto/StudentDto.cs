using System;
using CleanArchitecture.Domain.Models;
using MediatR;
namespace CleanArchitecture.Application.Students.Dto
{

    public class StudentDto
    {
       //  // public IQueryable<Student> Students { get; set; }
       //
       //  // public string BirthDate { get; set; }
       //
       //  public int id { get; set; }
       //
       //  public string personNumber { get; set; }
       //
       //  public string name { get; set; }
       //
       //  public string lastName { get; set; }
       //
       // // public string birthDate { get; set; }
       //
       //  public string sex { get; set; }


       public int Id { get; set; }

       public string PersonNumber { get; set; }

       public string Name { get; set; }

       public string LastName { get; set; }
       //[Required]
      // public DateTime BirthDate { get; set; }

       public string Sex { get; set; }
    }
}
