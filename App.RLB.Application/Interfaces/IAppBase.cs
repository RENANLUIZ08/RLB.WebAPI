using App.RLB.Application.DTO;
using App.RLB.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.RLB.Application.Interfaces
{
    public interface IAppBase<Entidade, EntidadeDTO> where Entidade: EntityBase where EntidadeDTO : DTOBase
    {
        EntidadeDTO Insert(EntidadeDTO entityDTO);
        EntidadeDTO Update(EntidadeDTO entityDTO);
        void Delete(EntidadeDTO entityDTO);
        IEnumerable<EntidadeDTO> All { get; }
        IQueryable<EntidadeDTO> Get(Expression<Func<EntidadeDTO, bool>> where);
        EntidadeDTO GetFirst(Expression<Func<EntidadeDTO, bool>> where);
        EntidadeDTO GetByKey(params object[] key);
        IQueryable<EntidadeDTO> AsNoTraking();
        IQueryable<EntidadeDTO> AsQueryable();
        IEnumerable<EntidadeDTO> GetMany();
    }
}
