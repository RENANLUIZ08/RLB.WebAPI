using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.RLB.Domain.Interface.Repositories
{
    public interface IRepositoryBase<Entidade> where Entidade : class 
    {

        Entidade Add(Entidade entity);
        Entidade Edit(Entidade entity);
        void Remove(Entidade entity);
        IEnumerable<Entidade> All { get; }
        IQueryable<Entidade> Get(Expression<Func<Entidade, bool>> predicate);
        Entidade GetFirst(Expression<Func<Entidade, bool>> predicate);
        Entidade GetByKey(params object[] key);
        IQueryable<Entidade> AsNoTraking();
        IQueryable<Entidade> AsQueryable();
        IEnumerable<Entidade> GetMany();
    }
}
