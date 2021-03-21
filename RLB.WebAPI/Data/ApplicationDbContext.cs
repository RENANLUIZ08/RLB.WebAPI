using App.RLB.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace App.RLB.WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //this.Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        
       // public DbSet<Pessoa> Pessoas { get; set; }
        //public DbSet<PJuridica> PessoasJuridicas { get; set; }
        //public DbSet<PFisica> PessoasFisicas { get; set; }
        //public DbSet<Endereco> Enderecos { get; set; }
        //public DbSet<Contato> Contatos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
