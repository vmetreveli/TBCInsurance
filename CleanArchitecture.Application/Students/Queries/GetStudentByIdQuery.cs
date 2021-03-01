using MediatR;
using CleanArchitecture.Application.Students.Dto;
namespace CleanArchitecture.Application.Students.Queries
{
    public class GetStudentByIdQuery: IRequest<StudentDto>
    {
        public int Id { get; set; }
    }
}