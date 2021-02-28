using System.Collections.Generic;
using System.Linq;
using MediatR;
using TBCInsurance.Application.Students.Dto;
namespace TBCInsurance.Application.Students.Queries
{
    public class GetAllStudentsQuery: IRequest<IEnumerable<StudentDto>>
    {

    }
}