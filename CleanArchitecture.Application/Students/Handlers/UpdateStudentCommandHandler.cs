using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Commands;
using CleanArchitecture.Application.Students.Dto;
using MediatR;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
     private readonly IStudentService _service;
        public UpdateStudentCommandHandler(IStudentService service)
        {
            _service = service;

        }
        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken) =>
            await _service.UpdateStudent(request.Student);
    }
}