﻿namespace CleanArchitecture.Application.Students.Dto
{

    public class StudentDto
    {

        public int Id { get; set; }

        public string PersonNumber { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public override string ToString() =>
            $"Id: {Id}, PersonNumber: {PersonNumber}, Name: {Name}, LastName: {LastName}, Sex: {Sex}";

    }
}