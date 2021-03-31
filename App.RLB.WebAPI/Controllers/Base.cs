using App.RLB.Application.DTO;
using App.RLB.Application.Interfaces;
using App.RLB.Domain.Entity;
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
        [Route("")]
        public IActionResult Insert([FromBody] EntidadeDTO dto)
        {
            try
            {
                var uri = Url.Action("Recuperar", new { id = dto.Id });
                return new CreatedResult(uri,app.Insert(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
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
        public IActionResult Delete(Guid? Id)
        {
            try
            {
                var get = app.GetByKey(Id);
                if(get == null)
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
        public IActionResult GetByKey(Guid? Id)
        {
            try
            {
                var get = app.GetByKey(Id);
                return new OkObjectResult(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult SelectAll()
        {
            try
            {
                var get = app.GetMany();
                if (get.Count() > 0)
                { return new OkObjectResult(get.ToString()); }
                else
                { return NotFound(); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
