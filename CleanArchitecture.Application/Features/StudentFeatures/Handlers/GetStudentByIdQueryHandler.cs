using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Application.Students.Queries;
using MediatR;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
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
