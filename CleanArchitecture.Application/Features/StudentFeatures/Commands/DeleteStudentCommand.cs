using MediatR;
namespace CleanArchitecture.Application.Features.StudentFeatures.Commands
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; init; }
    }
}
