using App.RLB.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static App.RLB.WebAPI.Service.DataAnottationValidacoes;

namespace App.RLB.WebAPI.Models
{
    [Table("Cadastro.Pessoas")]
    public class Pessoa
    {
        [HiddenInput]
        public Guid Id { get; set; }
        public virtual IEnumerable<Contato> Contatos { get; set; }
        public virtual IEnumerable<Endereco> Enderecos { get; set; }

        [ForeignKey("PFisica")]
        public Guid? PfisicaId { get; set; }
        public virtual PFisica PFisica { get; set; }

        [ForeignKey("PJuridica")]
        public Guid? PjuridicaId { get; set; }
        public virtual PJuridica PJuridica { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(PessoaDTO dto)
        {
            Id = dto.Id;
            Contatos = dto.Contatos.Select(c => new Contato(c));
            Enderecos = dto.Enderecos.Select(e => new Endereco(e));
        }
    }
    [Table("Cadastro.Contatos")]
    public class Contato
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [DisplayName("Telefone Fixo")]
        [MaxLength(12)]
        public string Telefone { get; set; }
        [DisplayName("Telefone Celular")]
        [MaxLength(13)]
        public string Celular { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public Contato()
        {

        }

        public Contato(ContatoDTO dto)
        {
            Id = dto.Id;
            Telefone = dto.Telefone;
            Celular = dto.Celular;
            PessoaId = dto.Pessoa.Id;
            Pessoa = new Pessoa(dto.Pessoa);
        }
    }
    [Table("Cadastro.Enderecos")]
    public class Endereco
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [MinLength(10, ErrorMessage = "O nome da Rua/Avenida deve conter no mínimo 10 caractéres.")]
        [Required(ErrorMessage = "Informe o nome da Rua/Avenida para o cadastro.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Informe o número do seu endereço.")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Informe o bairro do seu endereço.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Informe o cep do seu endereço.")]
        public string Cep { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public Endereco()
        {

        }

        public Endereco(EnderecoDTO dto)
        {
            Id = dto.Id;
            Logradouro = dto.Logradouro;
            Numero = dto.Numero;
            Complemento = dto.Complemento;
            Bairro = dto.Bairro;
            Cep = dto.Cep;
            PessoaId = dto.Pessoa.Id;
            Pessoa = new Pessoa(dto.Pessoa);
        }
    }
    [Table("Cadastro.PessoaFisica")]
    public class PFisica
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Informar nome completo para o cadastro")]
        public string Nome { get; set; }
        [ValidarCPF]
        public string Cpf { get; set; }
        [MaxLength(12)]
        public string Rg { get; set; }
        [IdadeMinima]
        public DateTime DataNascimento { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public PFisica()
        {

        }

        public PFisica(PFisicaDTO dto)
        {
            Id = dto.Id;
            Nome = dto.Nome;
            Cpf = dto.Cpf;
            Rg = dto.Rg;
            DataNascimento = dto.DataNascimento;
            PessoaId = dto.Pessoa.Id;
            Pessoa = new Pessoa(dto.Pessoa);

        }
    }
    [Table("Cadastro.PessoaJuridica")]
    public class PJuridica
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Informar a Razão Social para o cadastro")]
        public string RazaoSocial { get; set; }
        [ValidarCNPJ]
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string Im { get; set; }
        public string Proprietario { get; set; }

        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public PJuridica()
        {

        }

        public PJuridica(PJuridicaDTO dto)
        {
            Id = dto.Id;
            RazaoSocial = dto.RazaoSocial;
            Cnpj = dto.RazaoSocial;
            Ie = dto.Ie;
            Im = dto.Im;
            Proprietario = dto.Proprietario;
            PessoaId = dto.Pessoa.Id;
            Pessoa = new Pessoa(dto.Pessoa);

        }
    }
}
