using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Application.Students.Queries;
using MediatR;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IQueryable<StudentDto>>
    {
        private readonly IStudentService _service;

        public GetAllStudentsQueryHandler(IStudentService service) =>
            _service = service;
        public async Task<IQueryable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken) =>
            await _service.GetStudents();
    }
}