using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using App.RLB.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Infra.Data.Repository
{
    public class RepositoryBase<Entidade>: IRepositoryBase<Entidade> where Entidade: EntityBase
    {
        protected readonly Contexto contexto;

        public RepositoryBase(Contexto contexto): base()
        {
            this.contexto = contexto;
        }

        public IEnumerable<Entidade> All => contexto.Set<Entidade>().all;

        public Entidade Add(Entidade entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entidade> AsNoTraking()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entidade> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public Entidade Edit(Entidade entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entidade> Get(Expression<Func<Entidade, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Entidade GetByKey(params object[] key)
        {
            throw new NotImplementedException();
        }

        public Entidade GetFirst(Expression<Func<Entidade, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entidade> GetMany()
        {
            throw new NotImplementedException();
        }

        public void Remove(Entidade entity)
        {
            throw new NotImplementedException();
        }
    }
}
