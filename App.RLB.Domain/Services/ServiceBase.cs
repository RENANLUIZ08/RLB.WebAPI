using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.RLB.Domain.Services
{
    public class ServiceBase<Entidade> : IServiceBase<Entidade> where Entidade : EntityBase
    {
        protected readonly IRepositoryBase<Entidade> repository;

        public ServiceBase(IRepositoryBase<Entidade> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Entidade> All => repository.All;

        public IQueryable<Entidade> AsNoTraking()
        {
           return repository.AsNoTraking();
        }

        public IQueryable<Entidade> AsQueryable()
        {
            return repository.AsQueryable();
        }

        public Entidade Insert(Entidade entity)
        {
            return repository.Add(entity);
        }

        public Entidade Update(Entidade entity)
        {
            return repository.Edit(entity);
        }
        public void Delete(Entidade entity)
        {
            repository.Remove(entity);
        }
        public IQueryable<Entidade> Get(Expression<Func<Entidade, bool>> where)
        {
            return repository.Get(where);
        }

        public Entidade GetByKey(params object[] key)
        {
            return repository.GetByKey(key);
        }

        public Entidade GetFirst(Expression<Func<Entidade, bool>> where)
        {
            return repository.GetFirst(where);
        }

        public IEnumerable<Entidade> GetMany()
        {
            return repository.GetMany();
        }
    }
}
