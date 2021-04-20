using App.RLB.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.RLB.Domain.Core.Shared.DTO
{
    public class PessoaDTO : DTOBase
    {
        public IEnumerable<ContatoDTO> Contatos { get; set; }
        public IEnumerable<EnderecoDTO> Enderecos { get; set; }
        public virtual PFisicaDTO Fisica { get; set; }
        public virtual PJuridicaDTO Juridica { get; set; }

        public PessoaDTO()
        {

        }
        public PessoaDTO(Guid id, IEnumerable<Contact> contacts, IEnumerable<Address> address, PhysicalPerson physical, LegalPerson legal)
        {
            Id = id;
            Contatos = contacts.Select(c => ContatoDTO.MontarDTO(c));
            Enderecos = address.Select(a => EnderecoDTO.MontarDTO(a));
            Fisica = PFisicaDTO.MontarDTO(physical);
            Juridica = PJuridicaDTO.MontarDTO(legal);
        }

        public static PessoaDTO MontarDTO(Person person)
        => new PessoaDTO(person.Id, person.Contacts, person.Addresses, person.Physical, person.Legal);

    }

    public class PFisicaDTO : DTOBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public PessoaDTO Pessoa { get; set; }

        public PFisicaDTO()
        {

        }

        public PFisicaDTO(Guid id, string nome, string cpf, string rg, DateTime datanascimento, Person person)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = datanascimento;
            Pessoa = PessoaDTO.MontarDTO(person);
        }

        public static PFisicaDTO MontarDTO(PhysicalPerson physical)
            => new PFisicaDTO(physical.Id, physical.Nome, physical.Cpf, physical.Rg, physical.DataNascimento, physical.Pessoa);
    }

    public class PJuridicaDTO : DTOBase
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string Im { get; set; }
        public string Proprietario { get; set; }
        public PessoaDTO Pessoa { get; set; }
        public PJuridicaDTO()
        {

        }

        public PJuridicaDTO(Guid id, string razaosocial, string cnpj, Person person, string nomeFantasia, string ie = "", string im = "", string proprietario = "")
        {
            Id = id;
            RazaoSocial = razaosocial;
            Cnpj = cnpj;
            Ie = ie;
            Im = im;
            Proprietario = proprietario;
            NomeFantasia = nomeFantasia;
            Pessoa = PessoaDTO.MontarDTO(person);
        }

        public static PJuridicaDTO MontarDTO(LegalPerson legal)
            => new PJuridicaDTO(legal.Id, legal.RazaoSocial, legal.Cnpj, legal.Pessoa, legal.NomeFantasia, legal.Ie, legal.Im, legal.Proprietario);

    }

    public class EnderecoDTO : DTOBase
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public PessoaDTO Pessoa { get; set; }

        public EnderecoDTO()
        {

        }
        public EnderecoDTO(Guid id, string logradouro, string numero, string complemento, string bairro, string cep, Person person)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Pessoa = PessoaDTO.MontarDTO(person);
        }

        public static EnderecoDTO MontarDTO(Address address)
            => new EnderecoDTO(address.Id, address.Logradouro, address.Numero, address.Complemento, address.Bairro, address.Cep, address.Pessoa);

    }

    public class ContatoDTO : DTOBase
    {
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public PessoaDTO Pessoa { get; set; }

        public ContatoDTO()
        {

        }
        public ContatoDTO(Guid id, Person person, string email, string telefone = "", string celular = "")
        {
            Id = id;
            Telefone = telefone;
            Celular = celular;
            Email = email;
            Pessoa = PessoaDTO.MontarDTO(person);
        }

        public static ContatoDTO MontarDTO(Contact contact)
            => new ContatoDTO(contact.Id, contact.Pessoa, contact.Email, contact.Telefone, contact.Celular);

    }
}
