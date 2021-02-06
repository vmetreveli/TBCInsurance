using System;
using System.Collections.Generic;
using System.Text;

namespace TBCInsurance.Domain.Models
{
    public  class Student
    {
        public int Id { get; set; }
        public string PersonNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }

    }
}
