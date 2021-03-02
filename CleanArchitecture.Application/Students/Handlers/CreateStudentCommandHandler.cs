using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Commands;
using MediatR;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IStudentService _service;

        public CreateStudentCommandHandler(IStudentService service) =>
            _service = service;

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.AddStudent(request.Students);
            return result;
        }
    }
}