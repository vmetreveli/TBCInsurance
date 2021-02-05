using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TBCInsurance.Application;
using TBCInsurance.Application.Interfaces;
namespace CleanArchitecture.MVC.Controllers
{
    public class StudentController: Controller
    {
        private IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;
        
        public StudentController(ILogger<StudentController> logger, IStudentService bookService)
        {
            _logger = logger;
            _studentService = bookService;
        }
        public StudentViewModel Index()
        {
            StudentViewModel model = _studentService.GetStudents();
            return model;
        }
    }
}
