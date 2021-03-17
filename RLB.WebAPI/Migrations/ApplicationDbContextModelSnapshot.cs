﻿// <auto-generated />
using System;
using App.RLB.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.RLB.WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.RLB.WebAPI.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PFisicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PJuridicaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PFisicaId");

                    b.HasIndex("PJuridicaId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Celular")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Telefone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Cadastro.Contatos");
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Cadastro.Enderecos");
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Cadastro.Pessoas");
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.PFisica", b =>
                {
                    b.HasBaseType("App.RLB.WebAPI.Models.Pessoa");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Rg")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.ToTable("Cadastro.PessoaFisica");
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.PJuridica", b =>
                {
                    b.HasBaseType("App.RLB.WebAPI.Models.Pessoa");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("im")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("proprietario")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Cadastro.PessoaJuridica");
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.Cliente", b =>
                {
                    b.HasOne("App.RLB.WebAPI.Models.PFisica", "Fisica")
                        .WithMany()
                        .HasForeignKey("PFisicaId");

                    b.HasOne("App.RLB.WebAPI.Models.PJuridica", "Juridica")
                        .WithMany()
                        .HasForeignKey("PJuridicaId");

                    b.Navigation("Fisica");

                    b.Navigation("Juridica");
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.Contato", b =>
                {
                    b.HasOne("App.RLB.WebAPI.Models.Pessoa", "Pessoa")
                        .WithMany("Contatos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.Endereco", b =>
                {
                    b.HasOne("App.RLB.WebAPI.Models.Pessoa", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.PFisica", b =>
                {
                    b.HasOne("App.RLB.WebAPI.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("App.RLB.WebAPI.Models.PFisica", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.PJuridica", b =>
                {
                    b.HasOne("App.RLB.WebAPI.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("App.RLB.WebAPI.Models.PJuridica", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.RLB.WebAPI.Models.Pessoa", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
