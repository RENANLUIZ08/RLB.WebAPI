using App.RLB.Application.DTO;
using App.RLB.Application.Interfaces;
using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
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
    public abstract class Base<Entidade, EntidadeDTO> : ControllerBase
        where Entidade : EntityBase
        where EntidadeDTO : DTOBase
    {
        readonly protected IAppBase<Entidade, EntidadeDTO> app;
        readonly protected IRepositoryBase<Entidade> repository;
        public Base(IAppBase<Entidade, EntidadeDTO> app, IRepositoryBase<Entidade> repositoryBase)
        {
            this.app = app;
            this.repository = repositoryBase;
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
