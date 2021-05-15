using System;
namespace CleanArchitecture.Application.Features.CompanyFeatures.Dto
{

    public class CompanyDto
    {

        public int Id { get; set; }

        public string CompanyName { get; set; }

        public DateTime Time { get; set; }

        public override string ToString() =>
            $"Id: {Id}, CompanyName: {CompanyName}, Time: {Time}";
    }
}