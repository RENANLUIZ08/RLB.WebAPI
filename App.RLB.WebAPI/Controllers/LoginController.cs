using App.RLB.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService loginService;
        public LoginController(LoginService _loginService)
        {
            loginService = _loginService;
        }
        [HttpPost]
        public IActionResult Token()
        {
            return Ok();
        }
    }
}
