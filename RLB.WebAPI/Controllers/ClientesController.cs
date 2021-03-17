using App.RLB.WebAPI.DTO;
using App.RLB.WebAPI.Service.Interface;
using App.RLB.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        protected readonly ClienteService clienteService;
        public ClientesController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] ClienteDTO vm)
        {
            if(vm != null)
            {
                clienteService.Insert(vm);
                var uri = Url.Action("Recuperar", new { id = vm.Id });
                return Created(uri, vm);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update([FromBody] ClienteDTO vm)
        {
            if (vm != null)
            {
                clienteService.Edit(vm);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid? Id)
        {
            if (!Guid.Empty.Equals(Id.Value) || Id != null)
            {
                clienteService.Delete(Id.Value);
                return Ok();
            }
            return BadRequest(ModelState);

        }

        [HttpGet("{id}")]
        public IActionResult Edit(Guid? Id)
        {
            if (Id.HasValue? !Guid.Empty.Equals(Id.Value) || Id != null: false)
            {
                var cliente = clienteService.FindKey(Id.Value);
                if(cliente == null)
                { return NotFound(); }
                return Ok(cliente);
            }
            return BadRequest(ModelState);

        }

        [HttpGet]
        public IActionResult SelectAll()
        {
            var clientes = clienteService.SelectMany();
            if(clientes.Result.Count() > 1)
            { return Ok(clientes.ToString()); }
            return NotFound();
        }

    }
}
