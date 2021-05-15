using System.Linq;
using CleanArchitecture.Application.Features.StudentFeatures.Dto;
using MediatR;
namespace CleanArchitecture.Application.Features.StudentFeatures.Queries
{
    public class GetAllStudentsQuery : IRequest<IQueryable<StudentDto>>
    {
    }
}