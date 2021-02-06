using Microsoft.AspNetCore.Mvc;
using TBCInsurance.Application.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController: ControllerBase
    {
        private IStudentService _studentService;
        
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("index");
        }
    }
}
