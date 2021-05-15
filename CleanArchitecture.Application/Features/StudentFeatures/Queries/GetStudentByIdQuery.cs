using CleanArchitecture.Application.Features.StudentFeatures.Dto;
using MediatR;
namespace CleanArchitecture.Application.Features.StudentFeatures.Queries
{
    public abstract class GetStudentByIdQuery : IRequest<StudentDto>
    {
        public int Id { get; set; }
    }
}