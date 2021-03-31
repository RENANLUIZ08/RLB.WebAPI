using App.RLB.Application.DTO;
using App.RLB.Application.Interfaces;
using App.RLB.Domain.Entity;
using App.RLB.WebAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;

namespace App.RLB.WebAPI.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Base<Client, ClienteDTO>
    {
        public ClientesController(IClienteApp app) : base(app)
        { }
    }
}
