using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.RLB.WebAPI.Data.Repositories
{
    public interface IRepositoryBase<Entidade> where Entidade : class 
    {

        IQueryable<Entidade> All { get; }
        Entidade InsertDb(Entidade entity);
        Entidade UpdateDb(Entidade entity);
        void DeleteDb(Entidade entity);
        void DeleteAllDb(IEnumerable<Entidade> entity);
        void CommitWork();
        IQueryable<Entidade> AsNoTraking();
        IQueryable<Entidade> AsQueryable();
        Entidade GetOne(Guid Id);
        IEnumerable<Entidade> GetMany();
        Entidade GetWhere(Expression<Func<Entidade, bool>> where);

    }
}
