using System;
using System.Collections.Generic;
using System.Linq;
using TBCInsurance.Domain.Models;

namespace TBCInsurance.Application
{
    public class StudentViewModel
    {
       // public IQueryable<Student> Students { get; set; }
   
      // public string BirthDate { get; set; }
      
      public int Id { get; set; }
     
      public string PersonNumber { get; set; }

      public string Name { get; set; }
  
      public string LastName { get; set; }
      
      public string BirthDate { get; set; }

      public  string Sex { get; set; }


      public override string ToString()
      {
          return $"ID:{Id}, personalNumber{PersonNumber}, Name:{Name}, LastName:{LastName}, birthDate:{BirthDate}, Sex:{Sex}";
      }
    }
}
