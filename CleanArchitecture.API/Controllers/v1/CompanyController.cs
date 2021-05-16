using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Administrator")]
    public class CompanyController : ApiController
    {
    }
}