using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ApiVersion("1.0")]

    public class SecuredController : ApiController
    {
        [HttpPost]
        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> PostSecuredData()
        {
            return Ok("This Secured Data is available only for Authenticated Users.");
        }
    }
}