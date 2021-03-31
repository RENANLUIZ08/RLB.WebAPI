using App.RLB.Application.DTO;
using App.RLB.Application.Interfaces;
using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Application.Services
{
    public class ServiceAppBase<Entidade, EntidadeDTO> : IAppBase<Entidade, EntidadeDTO> where Entidade : EntityBase where EntidadeDTO : DTOBase
    {
        protected readonly IServiceBase<Entidade> service;
        protected readonly IMapper iMapper;

        public ServiceAppBase(IMapper iMapper, IServiceBase<Entidade> service): base() 
        {
            this.iMapper = iMapper;
            this.service = service;
        }

        public IEnumerable<EntidadeDTO> All => iMapper.Map<IEnumerable<EntidadeDTO>>(service.All);

        public IQueryable<EntidadeDTO> AsNoTraking()
        {
            return iMapper.Map<IQueryable<EntidadeDTO>>(service.AsNoTraking());
        }

        public IQueryable<EntidadeDTO> AsQueryable()
        {
            return iMapper.Map<IQueryable<EntidadeDTO>>(service.AsQueryable());
        }

        public void Delete(EntidadeDTO entityDTO)
        {
            service.Delete(iMapper.Map<Entidade>(entityDTO));
        }

        public IQueryable<EntidadeDTO> Get(Expression<Func<EntidadeDTO, bool>> where)
        {
            return iMapper.Map<IQueryable<EntidadeDTO>>(service.Get(iMapper.Map<Expression<Func<Entidade, bool>>>(where)));
        }

        public EntidadeDTO GetByKey(params object[] key)
        {
            return iMapper.Map<EntidadeDTO>(service.GetByKey(key));
        }

        public EntidadeDTO GetFirst(Expression<Func<EntidadeDTO, bool>> where)
        {
            return iMapper.Map<EntidadeDTO>(service.GetFirst(iMapper.Map<Expression<Func<Entidade, bool>>>(where)));
        }

        public IEnumerable<EntidadeDTO> GetMany()
        {
            return iMapper.Map<IEnumerable<EntidadeDTO>>(service.GetMany());
        }

        public EntidadeDTO Insert(EntidadeDTO entityDTO)
        {
            return iMapper.Map<EntidadeDTO>(service.Insert(iMapper.Map<Entidade>(entityDTO)));
        }

        public EntidadeDTO Update(EntidadeDTO entityDTO)
        {
            return iMapper.Map<EntidadeDTO>(service.Update(iMapper.Map<Entidade>(entityDTO)));
        }
    }

}
