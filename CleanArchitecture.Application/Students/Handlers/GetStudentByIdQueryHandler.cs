using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Application.Students.Queries;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class GetStudentByIdQueryHandler: IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IStudentService _service;


        public GetStudentByIdQueryHandler(IStudentService service)
        {
            _service = service;

        }
        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
           return await _service.GetStudentById(request.Id);
        }
    }
}