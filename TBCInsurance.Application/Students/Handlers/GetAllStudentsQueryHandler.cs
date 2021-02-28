using System.Collections.Generic;
using System.Linq;
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
    public class GetAllStudentsQueryHandler: IRequestHandler<GetAllStudentsQuery, IQueryable<StudentDto>>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IQueryable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();
            return _mapper.Map<IQueryable<StudentDto>>(result);
        }
    }
}