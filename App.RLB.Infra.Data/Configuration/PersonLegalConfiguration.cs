using App.RLB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Infra.Data.Configuration
{
    public class PersonLegalConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.PessoaId).IsRequired();

            builder.Property(c => c.Logradouro)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Bairro)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.Property(c => c.Numero)
                .HasMaxLength(5)
                .HasColumnType("int");

        }

    }
}
