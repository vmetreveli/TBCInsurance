using CleanArchitecture.Application.Features.StudentFeatures.Dto;
using MediatR;
namespace CleanArchitecture.Application.Features.StudentFeatures.Commands
{
    public class CreateStudentCommand : IRequest<int>
    {
        public StudentDto Students { get; init; }
    }
}
