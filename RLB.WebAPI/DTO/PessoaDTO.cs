using App.RLB.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.DTO
{
    public class PessoaDTO
    {
        public Guid Id { get; set; }
        public IEnumerable<ContatoDTO> Contatos { get; set; }
        public IEnumerable<EnderecoDTO> Enderecos { get; set; }

        public PessoaDTO()
        {

        }
        public PessoaDTO(Guid id, IEnumerable<Contato> contatos, IEnumerable<Endereco> enderecos)
        {
            Id = id;
            Contatos = contatos.Select(c => new ContatoDTO().MontarDTO(c));
            Enderecos = enderecos.Select(e => new EnderecoDTO().MontarDTO(e));
        }

        public PessoaDTO MontarDTO(Pessoa pessoa)
        => new PessoaDTO(pessoa.Id, pessoa.Contatos, pessoa.Enderecos);

    }

    public class PFisicaDTO : PessoaDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }

        public PFisicaDTO()
        {

        }

        public PFisicaDTO(Guid id, string nome, string cpf, string rg, DateTime datanascimento, IEnumerable<Contato> contatos, IEnumerable<Endereco> enderecos)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = datanascimento;

            Contatos = contatos.Select(c => new ContatoDTO().MontarDTO(c));
            Enderecos = enderecos.Select(e => new EnderecoDTO().MontarDTO(e));
        }

        public PFisicaDTO MontarDTO(PFisica pFisica)
            => new PFisicaDTO(pFisica.Id, pFisica.Nome, pFisica.Cpf, pFisica.Rg, pFisica.DataNascimento, pFisica.Contatos, pFisica.Enderecos);
    }

    public class PJuridicaDTO : PessoaDTO
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string Im { get; set; }
        public string Proprietario { get; set; }

        public PJuridicaDTO()
        {

        }

        public PJuridicaDTO(Guid id, string razaosocial, string cnpj, IEnumerable<Contato> contatos, IEnumerable<Endereco> enderecos, string ie = "", string im = "", string proprietario = "")
        {
            Id = id;
            RazaoSocial = razaosocial;
            Cnpj = cnpj;
            Ie = ie;
            Im = im;
            Proprietario = proprietario;
        }

        public PJuridicaDTO MontarDTO(PJuridica pJuridica)
            => new PJuridicaDTO(pJuridica.Id, pJuridica.RazaoSocial, pJuridica.Cnpj, pJuridica.Contatos, pJuridica.Enderecos, pJuridica.ie, pJuridica.im, pJuridica.proprietario);

    }

    public class EnderecoDTO
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public PessoaDTO Pessoa { get; set; }

        public EnderecoDTO()
        {

        }
        public EnderecoDTO(Guid id, string logradouro, string numero, string complemento, string bairro, string cep, Pessoa pessoa)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Pessoa = new PessoaDTO().MontarDTO(pessoa);
        }

        public EnderecoDTO MontarDTO(Endereco endereco)
            => new EnderecoDTO(endereco.Id, endereco.Logradouro, endereco.Numero, endereco.Complemento, endereco.Bairro, endereco.Cep, endereco.Pessoa);
        
    }

    public class ContatoDTO
    {
        public Guid Id { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public PessoaDTO Pessoa { get; set; }

        public ContatoDTO()
        {

        }
        public ContatoDTO(Guid id, Pessoa pessoa, string telefone = "", string celular = "")
        {
            Id = id;
            Telefone = telefone;
            Celular = celular;
            Pessoa = new PessoaDTO().MontarDTO(pessoa);
        }

        public ContatoDTO MontarDTO(Contato contato)
            => new ContatoDTO(contato.Id, contato.Pessoa, contato.Telefone, contato.Celular);

    }
}
