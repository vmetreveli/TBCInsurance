using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using MediatR;
using TBCInsurance.Application.Students.Commands;
namespace TBCInsurance.Application.Students.Handlers
{
    public class UpdateStudentCommandHandler: IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Update(_mapper.Map<Student>(request));
            return result;
        }
    }
}