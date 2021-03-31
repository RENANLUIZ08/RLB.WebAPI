using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.ModelsApi
{
    public class LoginApi
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
