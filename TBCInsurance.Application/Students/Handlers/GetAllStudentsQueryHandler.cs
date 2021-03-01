using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using TBCInsurance.Application.Students.Dto;
using TBCInsurance.Application.Students.Queries;
namespace TBCInsurance.Application.Students.Handlers
{
    public class GetAllStudentsQueryHandler: IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAll().Result;
            
           // var r= _mapper.Map<IQueryable<StudentDto>,IQueryable<Student>>;

            // return result.Result.Select(i =>new StudentDto
            // {
            //
            // });
           // return r;
           return _mapper.Map<IEnumerable<StudentDto>>(result);
        }
    }
}