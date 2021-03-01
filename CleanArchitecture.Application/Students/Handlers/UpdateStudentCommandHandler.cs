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
    public class UpdateStudentCommandHandler: IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;
        public UpdateStudentCommandHandler(IStudentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

        }
        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _service.UpdateStudent(_mapper.Map<StudentDto>(request));
        }
    }
}