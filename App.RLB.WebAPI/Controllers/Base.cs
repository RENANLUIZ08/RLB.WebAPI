using App.RLB.Application.Interfaces;
using App.RLB.Domain.Core.Shared.DTO;
using App.RLB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.RLB.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class Base<Entidade, EntidadeDTO> : ControllerBase
        where Entidade : EntityBase
        where EntidadeDTO : DTOBase
    {
        readonly protected IAppBase<Entidade, EntidadeDTO> app;
        public Base(IAppBase<Entidade, EntidadeDTO> app)
        {
            this.app = app;
        }

        [HttpPost]
        public abstract IActionResult Insert([FromBody] EntidadeDTO dto);

        [HttpPut]
        public abstract IActionResult Update([FromBody] EntidadeDTO dto);

        [HttpDelete]
        [Route("{Id}")]
        public abstract IActionResult Delete(Guid? Id);

        [HttpGet]
        [Route("{Id}")]
        public abstract IActionResult GetByKey(Guid? Id);

        [HttpGet]
        public abstract IActionResult SelectAll();
    }
}
