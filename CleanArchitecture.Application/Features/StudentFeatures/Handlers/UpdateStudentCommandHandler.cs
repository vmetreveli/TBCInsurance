using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Commands;
using MediatR;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentService _service;
        public UpdateStudentCommandHandler(IStudentService service) =>
            _service = service;
        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken) =>
            await _service.UpdateStudent(request.Student);
    }
}