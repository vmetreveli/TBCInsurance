using MediatR;
using CleanArchitecture.Application.Students.Dto;
namespace CleanArchitecture.Application.Students.Queries
{
    public abstract class GetStudentByIdQuery: IRequest<StudentDto>
    {
        public int Id { get; set; }
    }
}