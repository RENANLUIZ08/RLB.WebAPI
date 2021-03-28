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
        public DbSet<Cliente> Clientes { get; set; }
    }
}
