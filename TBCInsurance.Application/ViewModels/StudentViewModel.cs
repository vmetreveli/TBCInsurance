using System;
using System.Collections.Generic;
using TBCInsurance.Domain.Models;

namespace TBCInsurance.Application
{
    public class StudentViewModel
    {
        public IEnumerable<Student> Students { get; set; }
    }
}
