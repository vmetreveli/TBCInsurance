using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Commands;
using CleanArchitecture.Application.Students.Dto;

namespace CleanArchitecture.Application.Students.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IStudentService _service;

        public CreateStudentCommandHandler(IStudentService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.AddStudent(request.Students);
            return result;
        }
    }
}