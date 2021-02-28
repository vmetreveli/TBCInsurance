using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using TBCInsurance.Application.Students.Dto;
using TBCInsurance.Application.Students.Queries;
namespace TBCInsurance.Application.Students.Handlers
{
    public class GetStudentByIdQueryHandler: IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(request.Id);
            return _mapper.Map<StudentDto>(result);
        }
    }
}