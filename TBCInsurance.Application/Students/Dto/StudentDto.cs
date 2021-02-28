﻿using MediatR;
namespace TBCInsurance.Application.Students.Dto
{
    public class StudentDto:IRequest
    {
        // public IQueryable<Student> Students { get; set; }

        // public string BirthDate { get; set; }

        public int id { get; set; }

        public string personNumber { get; set; }

        public string name { get; set; }

        public string lastName { get; set; }

        public string birthDate { get; set; }

        public string sex { get; set; }
    }
}
