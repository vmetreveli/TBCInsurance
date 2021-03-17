using CleanArchitecture.Application.Students.Dto;
using MediatR;
namespace CleanArchitecture.Application.Students.Queries
{
    public abstract class GetStudentByIdQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
    }
}
