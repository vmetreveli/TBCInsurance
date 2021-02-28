using MediatR;
using TBCInsurance.Application.Students.Dto;
namespace TBCInsurance.Application.Students.Queries
{
    public class GetStudentByIdQuery: IRequest<StudentDto>
    {
        public int Id { get; set; }
    }
}