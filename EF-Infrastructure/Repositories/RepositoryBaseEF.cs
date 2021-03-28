using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EF.Infrastructure.Data.Repositories
{
    public class RepositoryBaseEF<Entidade> : IDisposable, IRepositoryBase<Entidade> where Entidade : class
    {
        private readonly DbContext Context;

        public IQueryable<Entidade> All => Context.Set<Entidade>().AsQueryable();

        public RepositoryBaseEF(DbContext dbContext)
        {
            Context = dbContext;
        }

        public void CommitWork()
        {
            Context.SaveChanges();
            Dispose();
        }

        public Entidade InsertDb(Entidade entity)
        {
            Context.Set<Entidade>().Add(entity);
            return entity;
        }

        public void DeleteDb(Entidade entity)
        {
            Context.Set<Entidade>().Remove(entity);
        }

        public void DeleteAllDb(IEnumerable<Entidade> entity)
        {
            entity.ToList().ForEach(c =>
            {
                this.DeleteDb(c);
            });
        }

        public Entidade UpdateDb(Entidade entity)
        {
            Context.Set<Entidade>().Update(entity);
            return entity;
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        public IQueryable<Entidade> AsNoTraking()
        {
            return Context.Set<Entidade>().AsNoTracking();
        }

        public IQueryable<Entidade> AsQueryable()
        {
            return Context.Set<Entidade>().AsQueryable();
        }

        public IEnumerable<Entidade> GetMany()
        {
            return Context.Set<Entidade>();
        }

        public Entidade GetOne(object param)
        {
            return Context.Set<Entidade>().Find(param);
        }
        public IQueryable<Entidade> GetWhere(Expression<Func<Entidade, bool>> where)
        {
            return Context.Set<Entidade>().Where(where);
        }
        public Entidade GetFirst(Expression<Func<Entidade, bool>> where)
        {
            return Context.Set<Entidade>().Where(where).FirstOrDefault();
        }
    }
}
