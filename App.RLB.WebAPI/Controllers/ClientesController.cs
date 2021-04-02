using App.RLB.Application.DTO;
using App.RLB.Application.Interfaces;
using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using App.RLB.Domain.Services;
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
        protected readonly ClienteService clienteService;
        public ClientesController(IAppBase<Client, ClienteDTO> app, IRepositoryBase<Client> repositoryBase) : base(app, repositoryBase)
        {
            clienteService = new ClienteService(;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastro de Cliente", Description = "EndPoint de Cadastro de Clientes")]
        [SwaggerResponse(statusCode: StatusCodes.Status201Created, description: "Cadastro Inserido com sucesso.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        public override IActionResult Insert([FromBody] ClienteDTO dto)
        {
            try
            {
                this.repository.

                serviceBase.All
                if (dto.Pessoa.Fisica != null)
                { serviceBase.ValidarClienteExistente(dto.Pessoa.Fisica.Cpf, null); }
                if (dto.Pessoa.Juridica != null)
                { ClienteService.ValidarClienteExistente(dto.Pessoa.Juridica.Cnpj, null); }

                var uri = Url.Action("GetByKey", new { Id = dto.Id });
                return new CreatedResult(uri, app.Insert(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Atualizacao de Cadastro de Clientes", Description = "EndPoint de Atualizacao de Cadastro de Cliente")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cadastro Atualizado com sucesso.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]

        public override IActionResult Update([FromBody] ClienteDTO dto)
        {
            try
            {
                app.Update(dto);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        [SwaggerOperation(Summary = "Atualizacao de Cadastro de Cliente", Description = "EndPoint de Atualizacao de Cadastro")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cadastro Atualizado com sucesso.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        public override IActionResult Delete(Guid? Id)
        {
            try
            {
                var get = app.GetByKey(Id);
                if (get == null)
                { return NotFound(); }
                else
                {
                    app.Delete(get);
                    return new OkObjectResult(true);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{Id}")]
        [SwaggerOperation(Summary = "Consultar Cliente pelo Id", Description = "EndPoint de consultar Entidade pelo Id")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Encontrou entidade pelo Id informado")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "O Identificador passado não encontrou nenhuma informação na Base de Dados")]
        public override IActionResult GetByKey(Guid? Id)
        {
            try
            {
                var get = app.GetByKey(Id);
                if (get == null)
                { return NotFound(); }
                return new OkObjectResult(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [SwaggerOperation(Summary = "Consultar todos os Clientes", Description = "EndPoint de consultar Entidades")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Encontrou lista de Entidades cadastradas")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Nao foram encontradas entidades na Base de Dados")]

        public override IActionResult SelectAll()
        {
            var get = app.GetMany();
            if (get.Count() > 0)
            { return new OkObjectResult(get.ToString()); }
            else
            { return NotFound(); }
        }
    }
}
