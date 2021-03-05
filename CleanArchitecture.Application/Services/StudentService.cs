using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Students.Dto;
using CleanArchitecture.Application.Utils;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
namespace CleanArchitecture.Application.Services
{

    public class StudentService : IStudentService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IMapper mapper, IRepository<Student> studentRepository, ILogger<StudentService> logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IQueryable<StudentDto>> GetStudents() =>
            _studentRepository.GetAll().Result.Select(i => _mapper.Map(i, new StudentDto()));

        public async Task<PagedResult<StudentDto>> FindStudents(string filter)
        {
            try
            {
                _logger.LogInformation($"FindStudents:{filter}");

                PageFilter obj = null;

                if (!string.IsNullOrEmpty(filter)) obj = JsonConvert.DeserializeObject<PageFilter>(filter);

                var query = !string.IsNullOrEmpty(obj?.PersonNumber)
                    ? _studentRepository.SearchFor(i => i.PersonNumber == obj.PersonNumber || i.LastName == obj.LastName ||
                                                        i.Name == obj.Name)
                    : _studentRepository.GetAll();

                return query.Result.Select(i => _mapper.Map(i, new StudentDto()))
                    .GetPaged(obj.PageIndex, obj.PageSize);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new PagedResult<StudentDto>();
            }
        }

        public async Task<int> AddStudent(StudentDto student)
        {
            try
            {
                _logger.LogInformation("AddStudent:");
                var st = _mapper.Map<Student>(student);

                if (_studentRepository.GetAll().Result.Any(i => i.PersonNumber == st.PersonNumber))
                    throw new Exception("ესეთი სტუდენტი უკვე არსებობს");

                /*if (DateTime.Today.Year - Convert.ToDateTime(st.BirthDate).Year < 16)
                    throw new Exception("ესეთი სტუდენტი დამატება დაუშვებელია");*/


                await _studentRepository.Add(st);

                return st.Id;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> RemoveStudent(int id)
        {
            try
            {
                _logger.LogInformation($"RemoveStudent:{id}");


                var student = _studentRepository.GetById(id).Result;
                if (student == null) return default;

                await _studentRepository.Delete(student);

                return id;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<int> UpdateStudent(StudentDto student)
        {
            try
            {
                _logger.LogInformation("Uppdate Student:");
                var st = _mapper.Map<Student>(student);

                if (_studentRepository.GetAll().Result.Any(i => i.PersonNumber == st.PersonNumber))
                    throw new Exception("ესეთი სტუდენტი უკვე არსებობს");

                // if (DateTime.Today.Year - Convert.ToDateTime(st.BirthDate).Year < 16)
                //     throw new Exception("ესეთი სტუდენტი დამატება დაუშვებელია");


                var stud = _studentRepository.GetById(st.Id).Result;
                st.Name = st.Name;
                st.Sex = st.Sex;
                st.LastName = st.LastName;
                st.PersonNumber = st.PersonNumber;

                await _studentRepository.Update(stud);

                return stud.Id;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<StudentDto> GetStudentById(int id)
        {
            var student = _studentRepository.GetById(id).Result;
            return _mapper.Map(student, new StudentDto());
        }
    }
}