using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using TBCInsurance.Application.Students.Commands;
namespace TBCInsurance.Application.Students.Handlers
{
    public class DeleteStudentCommandHandler: IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IRepository<Student> _repository;

        public DeleteStudentCommandHandler(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Delete(request.Student);
            return result;
        }
    }
}