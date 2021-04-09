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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.PessoaId).IsRequired();

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

        }

    }
}
