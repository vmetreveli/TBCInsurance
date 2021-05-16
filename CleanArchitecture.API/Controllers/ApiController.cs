using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{

    [ApiController]

    // [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiController : ControllerBase
    {
    }
}