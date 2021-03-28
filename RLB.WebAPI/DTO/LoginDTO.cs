using App.RLB.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Passwords { get; set; }
    }
}
