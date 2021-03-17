using System.Linq;
using CleanArchitecture.Application.Students.Dto;
using MediatR;
namespace CleanArchitecture.Application.Students.Queries
{
    public class GetAllStudentsQuery : IRequest<IQueryable<StudentDto>>
    {
    }
}
