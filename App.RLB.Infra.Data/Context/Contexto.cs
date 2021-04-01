using App.RLB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;

namespace App.RLB.Infra.Data.Context
{
    public class Contexto : DbContext
    {
        public DbSet<Client> Clientes { get; set; }

        public IDbContextTransaction Transaction { get; private set; }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
            if(Database.GetPendingMigrations().Count() > 0)
            {
                Database.Migrate();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public IDbContextTransaction InitialTransaction()
        {
            if(Transaction == null)
            { Transaction = this.Database.BeginTransaction(); }
            return Transaction;
        }

        private void Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw new Exception(ex.Message);
            }
        }

        private void RollBackTransaction()
        {
            if(!(Transaction == null))
            { Transaction.Rollback(); }
        }

        public void SendChanges()
        {
            Save();
            CommitWork();
        }

        private void CommitWork()
        {
            if(Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        private void CommitWorkAsync()
        {
            if (Transaction != null)
            {
                Transaction.CommitAsync();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        protected override void OnModelCreating(ModelBuilder mBuilder)
        {
            //base.OnModelCreating(mBuilder);
            //mBuilder.ApplyConfiguration(new ClienteMap());
        }
    }
}
