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
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Application.Students.Queries;
namespace CleanArchitecture.Application.Students.Handlers
{
    public class GetAllStudentsQueryHandler: IRequestHandler<GetAllStudentsQuery, IQueryable<StudentDto>>
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