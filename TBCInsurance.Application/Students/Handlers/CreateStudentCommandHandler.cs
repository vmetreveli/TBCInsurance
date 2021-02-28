using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using TBCInsurance.Application.Students.Commands;
namespace TBCInsurance.Application.Students.Handlers
{
    public class CreateStudentCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _repository;

        public CreateStudentCommandHandler(IRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Add(_mapper.Map<Student>(request));
            return result;
        }
    }
}