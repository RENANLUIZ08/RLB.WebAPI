using App.RLB.WebAPI.DTO;
using App.RLB.WebAPI.Services;
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
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService clienteService;
        public ClientesController(ClienteService _clienteService)
        {
            clienteService = _clienteService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastro de Clientes", Description = "EndPoint de Cadastro de Clientes")]
        [SwaggerResponse(statusCode: StatusCodes.Status201Created, description: "Cliente Inserido com sucesso.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        public IActionResult Insert([FromBody] ClienteDTO vm)
        {
            if (vm != null)
            {
                clienteService.Insert(vm);
                var uri = Url.Action("Recuperar", new { id = vm.Id });
                return Created(uri, vm);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPut]
        [SwaggerOperation(Summary = "Atualizacao de Clientes", Description = "EndPoint de Atualizacao de Clientes")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cliente atualizado com sucesso.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        public IActionResult Update([FromBody] ClienteDTO vm)
        {
            if (vm != null)
            {
                clienteService.Edit(vm);
                return Ok();
            }

            return BadRequest();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclusao de Clientes", Description = "EndPoint de Exclusao de Clientes")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cliente Excluido com Sucesso.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        public IActionResult Delete(Guid? Id)
        {
            if (!Guid.Empty.Equals(Id.Value) || Id != null)
            {
                clienteService.Delete(Id.Value);
                return Ok();
            }
            return BadRequest(ModelState);

        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Selecionar cliente Pelo ::Id::", Description = "EndPoint de selecionar cliente pelo ID de Clientes")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        public IActionResult Edit(Guid? Id)
        {
            if (Id.HasValue ? !Guid.Empty.Equals(Id.Value) || Id != null : false)
            {
                var cliente = clienteService.FindKey(Id.Value);
                if (cliente == null)
                { return NotFound(); }
                return Ok(cliente);
            }
            return BadRequest(ModelState);

        }

        [Authorize]
        [HttpGet]
        [SwaggerOperation(Summary = "Selecionar todos clientes", Description = "EndPoint de selecionar todos os Clientes")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Ocorreu um problema de selecionar os dados, tente novamente.")]
        public IActionResult SelectAll()
        {
            var clientes = clienteService.SelectMany();
            if (clientes.Result.Count() > 1)
            { return Ok(clientes.ToString()); }
            return NotFound();
        }

    }
}
