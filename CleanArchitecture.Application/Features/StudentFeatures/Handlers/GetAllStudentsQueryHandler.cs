using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.StudentFeatures.Dto;
using CleanArchitecture.Application.Features.StudentFeatures.Queries;
using CleanArchitecture.Application.Interfaces;
using MediatR;
namespace CleanArchitecture.Application.Features.StudentFeatures.Handlers
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IQueryable<StudentDto>>
    {
        private readonly IStudentService _service;

        public GetAllStudentsQueryHandler(IStudentService service)
        {
            _service = service;
        }
        public async Task<IQueryable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetStudents();
        }
    }
}
