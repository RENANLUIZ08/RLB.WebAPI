using App.RLB.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.RLB.Domain.Interface.Repositories
{
    public interface IServiceBase<Entidade> where Entidade : EntityBase 
    {

        Entidade Insert(Entidade entity);
        Entidade Update(Entidade entity);
        void Delete(Entidade entity);
        IEnumerable<Entidade> All { get; }
        IQueryable<Entidade> Get(Expression<Func<Entidade, bool>> predicate);
        Entidade GetFirst(Expression<Func<Entidade, bool>> predicate);
        Entidade GetByKey(params object[] key);
        IQueryable<Entidade> AsNoTraking();
        IQueryable<Entidade> AsQueryable();
        IEnumerable<Entidade> GetMany();
    }
}
