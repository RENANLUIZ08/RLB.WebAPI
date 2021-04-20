using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.RLB.Domain.Interface
{
    public interface IRepositoryBase<Entidade> where Entidade : class 
    {

        Entidade Insert(Entidade entity);
        Entidade Update(Entidade entity);
        void Delete(Entidade entity);
        IEnumerable<Entidade> All { get; }
        IEnumerable<Entidade> GetMany(Expression<Func<Entidade, bool>> predicate);
        Entidade GetFirst(Expression<Func<Entidade, bool>> predicate);
        Entidade GetByKey(params object[] key);
        IQueryable<Entidade> AsNoTraking();
        IQueryable<Entidade> AsQueryable();
        IEnumerable<Entidade> GetMany();
    }
}
