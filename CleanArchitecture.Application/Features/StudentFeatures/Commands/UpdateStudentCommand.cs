using CleanArchitecture.Application.Features.StudentFeatures.Dto;
using MediatR;
namespace CleanArchitecture.Application.Features.StudentFeatures.Commands
{
    public class UpdateStudentCommand : IRequest<int>
    {
        public StudentDto Student { get; init; }
    }
}