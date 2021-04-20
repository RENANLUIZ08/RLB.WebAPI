using Microsoft.AspNetCore.Mvc;

namespace App.RLB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Token()
        {
            return Ok();
        }
    }
}
