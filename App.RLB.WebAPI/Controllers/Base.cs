using App.RLB.Application.DTO;
using App.RLB.Application.Interfaces;
using App.RLB.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Base<Entidade, EntidadeDTO> : ControllerBase
        where Entidade : EntityBase
        where EntidadeDTO : DTOBase
    {
        readonly protected IAppBase<Entidade, EntidadeDTO> app;
        public Base(IAppBase<Entidade, EntidadeDTO> app)
        {
            this.app = app;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastro", Description = "EndPoint de Cadastro")]
        [SwaggerResponse(statusCode: StatusCodes.Status201Created, description: "Cadastro Inserido com sucesso.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        public IActionResult Insert([FromBody] EntidadeDTO dto)
        {
            try
            {
                var uri = Url.Action("GetByKey", new { Id = dto.Id });
                return new CreatedResult(uri, app.Insert(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Atualizacao de Cadastro", Description = "EndPoint de Atualizacao de Cadastro")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cadastro Atualizado com sucesso.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]

        public IActionResult Update([FromBody] EntidadeDTO dto)
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
        [SwaggerOperation(Summary = "Atualizacao de Cadastro", Description = "EndPoint de Atualizacao de Cadastro")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Cadastro Atualizado com sucesso.")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        public IActionResult Delete(Guid? Id)
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
        [SwaggerOperation(Summary = "Consultar Entidade pelo Id", Description = "EndPoint de consultar Entidade pelo Id")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Encontrou entidade pelo Id informado")]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest, description: "Verifique os dados enviados na requisicao e tente novamente.")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "O Identificador passado não encontrou nenhuma informação na Base de Dados")]

        public IActionResult GetByKey(Guid? Id)
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
        [SwaggerOperation(Summary = "Consultar todas Entidades", Description = "EndPoint de consultar Entidades")]
        [SwaggerResponse(statusCode: StatusCodes.Status200OK, description: "Encontrou lista de Entidades cadastradas")]
        [SwaggerResponse(statusCode: StatusCodes.Status404NotFound, description: "Nao foram encontradas entidades na Base de Dados")]

        public IActionResult SelectAll()
        {
            var get = app.GetMany();
            if (get.Count() > 0)
            { return new OkObjectResult(get.ToString()); }
            else
            { return NotFound(); }
        }
    }
}
