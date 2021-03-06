using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface;
using App.RLB.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.RLB.Infra.Data.Repository
{
    public class RepositoryBase<Entidade>: IRepositoryBase<Entidade> where Entidade: EntityBase
    {
        protected readonly Contexto contexto;

        public RepositoryBase(Contexto contexto): base()
        {
            this.contexto = contexto;
        }

        public IEnumerable<Entidade> All => contexto.Set<Entidade>().AsQueryable();

        public Entidade Insert(Entidade entity)
        {
            contexto.InitialTransaction();
            var entityFormad = contexto.Set<Entidade>().Add(entity).Entity;
            contexto.SendChanges();
            return (entityFormad);
        }
        public void Delete(Entidade entity)
        {
            contexto.InitialTransaction();
            contexto.Set<Entidade>().Remove(entity);
            contexto.SendChanges();
        }

        public Entidade Update(Entidade entity)
        {
            contexto.InitialTransaction();
            var entityFormad = contexto.Set<Entidade>().Update(entity).Entity;
            contexto.SaveChanges();
            return entityFormad;
        }
        public IQueryable<Entidade> AsNoTraking()
        {
            return contexto.Set<Entidade>().AsNoTracking();
        }

        public IQueryable<Entidade> AsQueryable()
        {
            return contexto.Set<Entidade>().AsQueryable();
        }



        public IEnumerable<Entidade> GetMany(Expression<Func<Entidade, bool>> where)
        {
            return contexto.Set<Entidade>().AsQueryable().Where(where).AsEnumerable();
        }

        public Entidade GetByKey(params object[] key)
        {
            return contexto.Set<Entidade>().Find(key);
        }

        public Entidade GetFirst(Expression<Func<Entidade, bool>> where)
        {
            return contexto.Set<Entidade>().AsQueryable().Where(where).FirstOrDefault();
        }

        public IEnumerable<Entidade> GetMany()
        {
            var teste = contexto.Set<Entidade>().ToList();
            return teste;
        }


    }
}
