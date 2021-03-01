using System.Collections.Generic;
using System.Linq;
using MediatR;
using CleanArchitecture.Application.Students.Dto;
namespace CleanArchitecture.Application.Students.Queries
{
    public class GetAllStudentsQuery: IRequest<IQueryable<StudentDto>>
    {

    }
}