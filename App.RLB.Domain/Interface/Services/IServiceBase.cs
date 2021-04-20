using App.RLB.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.RLB.Domain.Interface.Repositories
{
    public interface IServiceBase<Entidade> where Entidade : EntityBase 
    {

        Entidade Add(Entidade entity);
        Entidade Edit(Entidade entity);
        void Remove(Entidade entity);
        IEnumerable<Entidade> All { get; }
        IEnumerable<Entidade> GetMany(Expression<Func<Entidade, bool>> predicate);
        Entidade GetFirst(Expression<Func<Entidade, bool>> predicate);
        Entidade GetByKey(params object[] key);
        IQueryable<Entidade> AsNoTraking();
        IQueryable<Entidade> AsQueryable();
        IEnumerable<Entidade> GetMany();
    }
}
