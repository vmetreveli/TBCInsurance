using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.StudentFeatures.Dto;
using CleanArchitecture.Application.Features.StudentFeatures.Queries;
using CleanArchitecture.Application.Interfaces;
using MediatR;
namespace CleanArchitecture.Application.Features.StudentFeatures.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IStudentService _service;


        public GetStudentByIdQueryHandler(IStudentService service) =>
            _service = service;
        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken) =>
            await _service.GetStudentById(request.Id);
    }
}