using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.ModelsAPI
{
    [SwaggerSchema("Login do Usuario")]
    public class Login
    {
        [SwaggerParameter("Email usuario", Description = "E-mail", Required = true)]
        public string Email { get; set; }
        
        [SwaggerParameter("Senha usuario", Description = "Password", Required = true)]
        public string Senha { get; set; }
    }
}
