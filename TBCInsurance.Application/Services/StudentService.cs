using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TBCInsurance.Application.Interfaces;
using TBCInsurance.Application.Utils;
using TBCInsurance.Application.ViewModels;
namespace TBCInsurance.Application.Services
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

        public async Task<IQueryable<StudentViewModel>> GetStudents()
        {
            return _studentRepository.GetAll().Result.Select(i => new StudentViewModel
            {
                id = i.Id,
                birthDate = i.BirthDate.ToShortDateString(),
                lastName = i.LastName,
                name = i.Name,
                personNumber = i.PersonNumber,
                sex = i.Sex
            });
        }
        public async Task<PagedResult<StudentViewModel>> FindStudents(string filter)
        {
            try
            {
                _logger.LogInformation($"FindStudents:{filter}");

                PageFilter obj = null;

                if (!string.IsNullOrEmpty(filter)) obj = JsonConvert.DeserializeObject<PageFilter>(filter);

                var query = !string.IsNullOrEmpty(obj?.PersonNumber)
                    ? _studentRepository.SearchFor(i => i.PersonNumber == obj.PersonNumber ||
                                                        i.BirthDate == obj.BirthDate ||
                                                        i.LastName == obj.LastName ||
                                                        i.Name == obj.Name)
                    : _studentRepository.GetAll();

                var res = query.Result.Select(i => new StudentViewModel
                {
                    id = i.Id,
                    birthDate = i.BirthDate.ToShortDateString(),
                    lastName = i.LastName,
                    name = i.Name,
                    personNumber = i.PersonNumber,
                    sex = i.Sex
                }).GetPaged(obj.PageIndex, obj.PageSize);

                return res;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return new PagedResult<StudentViewModel>();
            }
        }
        public async Task<bool> AddStudent(StudentViewModel student)
        {
            try
            {
                _logger.LogInformation("AddStudent:");
                var st = _mapper.Map<Student>(student);

                if (_studentRepository.GetAll().Result.Any(i => i.PersonNumber == st.PersonNumber))
                    throw new Exception("ესეთი სტუდენტი უკვე არსებობს");

                if (DateTime.Today.Year - Convert.ToDateTime(st.BirthDate).Year < 16)
                    throw new Exception("ესეთი სტუდენტი დამატება დაუშვებელია");




                _studentRepository.Insert(st);

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public async Task<bool> RemoveStudent(int id)
        {
            try
            {
                _logger.LogInformation($"RemoveStudent:{id}");


                var student = _studentRepository.GetById(id).Result;

                if (student != null)
                {
                    _studentRepository.Delete(student);

                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateStudent(StudentViewModel student)
        {
            try
            {
                _logger.LogInformation("AddStudent:");
                var st = _mapper.Map<Student>(student);

                if (_studentRepository.GetAll().Result.Any(i => i.PersonNumber == st.PersonNumber))
                    throw new Exception("ესეთი სტუდენტი უკვე არსებობს");

                if (DateTime.Today.Year - Convert.ToDateTime(st.BirthDate).Year < 16)
                    throw new Exception("ესეთი სტუდენტი დამატება დაუშვებელია");


                var stud = _studentRepository.GetById(st.Id).Result;
                st.Name = st.Name;
                st.Sex = st.Sex;
                st.BirthDate = Convert.ToDateTime(st.BirthDate);
                st.LastName = st.LastName;
                st.PersonNumber = st.PersonNumber;

                _studentRepository.Update(stud);

                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
