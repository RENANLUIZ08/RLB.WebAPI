using App.RLB.WebAPI.Models;
using App.RLB.WebAPI.ModelsApi;
using App.RLB.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;
        public LoginController(SignInManager<User> _signInManager)
        {
            signInManager = _signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> TokenAsync([FromBody]LoginApi model)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Login, model.Password, true, true);
                if (result.Succeeded)
                {//criar token (header + payload>> claims(direitos) + signature)
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.Login),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                    var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rlb-webapi-authentication-validation"));
                    var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "App.RLB.WebAPI",
                        audience: "Swagger",
                        claims: claims, 
                        signingCredentials: credenciais,
                        expires: DateTime.Now.AddMinutes(30)
                        );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                return Unauthorized();//401
            }
            return Ok();
        }
    }
}
