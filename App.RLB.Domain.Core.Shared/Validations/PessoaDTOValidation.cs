using App.RLB.Domain.Core.Shared.DTO;
using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.RLB.Domain.Core.Shared.Validations
{
    public class CommandPessoaDTO : AbstractValidator<PessoaDTO>
    {
        #region Variables
        protected List<string> errosEntityToBase = null;
        #endregion

        #region Validacoes CNPJ
        protected void ValidatorNomeProprietario()
        {
            RuleFor(p => p.Juridica.Proprietario)
                .NotEmpty().WithMessage($"Por favor, preencha o nome do proprietário")
                .MinimumLength(4).WithMessage("O Nome do proprietário deve possuir ao menos 4 caracteres.")
                .MaximumLength(90).WithMessage("O Nome do proprietário deve possuir no máximo 90 caracteres.");
        }
        protected void ValidatorRazaoSocial()
        {
            RuleFor(p => p.Juridica.RazaoSocial)
                    .NotEmpty().WithMessage($"Por favor, preencha a razão social")
                    .MinimumLength(5).WithMessage("O Nome da Razão Social deve possuir ao menos 5 caracteres.")
                    .MaximumLength(100).WithMessage("O Nome do proprietário deve possuir no máximo 100 caracteres.");
        }
        protected void ValidatorNomeFantasia()
        {
            RuleFor(p => p.Juridica.NomeFantasia)
                .MaximumLength(100).WithMessage("O Nome do proprietário deve possuir no máximo 100 caracteres.");
        }
        protected void ValidadorCNPJ()
        {
            RuleFor(p => p.Juridica.Cnpj)
                .NotEmpty().WithMessage($"Por favor, preencha o CNPJ.")
                .MinimumLength(14)
                .MaximumLength(14).WithMessage("O CNPJ deve comter todos os números.")
                .Must(ValidaCNPJ).WithMessage("O CNPJ digitado está inválido, verifique.");

        }
        protected static bool ValidaCNPJ(string CNPJ)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            CNPJ = CNPJ.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (CNPJ.Length != 14)
                return false;

            string tempCnpj = CNPJ.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return CNPJ.EndsWith(digito);
        }
        #endregion

        #region Validacoes CPF
        protected void ValidatorNome()
        {
            RuleFor(p => p.Fisica.Nome)
                .NotEmpty().WithMessage($"Por favor, preencha seu nome")
                .MinimumLength(4).WithMessage("Seu Nome deve possuir ao menos 4 caracteres.")
                .MaximumLength(90).WithMessage("Seu nome deve possuir no máximo 90 caracteres.");
        }
        protected void ValidatorIdadeMinima()
        {
            RuleFor(p => p.Fisica.DataNascimento)
                .Must(IdadeMinima).WithMessage("Não é permitido cadastro para menores de 18 Anos.");
        }
        protected void ValidadorCPF()
        {
            RuleFor(p => p.Fisica.Cpf)
                .NotEmpty().WithMessage($"Por favor, preencha o CPF.")
                .MinimumLength(11)
                .MaximumLength(11).WithMessage("O CPF deve comter todos os números.")
                .Must(ValidaCNPJ).WithMessage("O CPF digitado está inválido, verifique.");

        }

        #region Functions for CPF
        protected static bool IdadeMinima(DateTime dataNasc)
        {
            return dataNasc <= DateTime.Now.AddYears(-18);
        }
        protected static bool ValidaCPF(string CPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            CPF = CPF.Trim().Replace(".", "").Replace("-", "");
            if (CPF.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == CPF)
                    return false;

            string tempCpf = CPF.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return CPF.EndsWith(digito);
        }
        #endregion

        #endregion

        #region Validacoes Enderecos
        protected void ValidatorEnderecos()
        {
            //   RuleForEach(p => p.Enderecos).SetValidator(new AddressValidation());
        }
        #endregion

        #region Validacoes Enderecos
        protected void ValidatorContatos()
        {
            //RuleForEach(p => p.Contatos).SetValidator(new CommandNewAddress());
        }
        #endregion

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateExists(IServiceBase<Person> service)
        {
            List<string> errosEntityToBase = null;
            RuleFor(p => p).Must(ValidateExists).WithMessage(string.Join(", ", errosEntityToBase.ToArray()));
            bool ValidateExists(PessoaDTO pessoaDTO)
            {
                errosEntityToBase = new List<string>();
                var (id, documento) = RecuperarDocId(pessoaDTO).Result;

                Expression<Func<Person, bool>> where = (fp) => fp.Physical.Cpf == documento || fp.Legal.Cnpj == documento;
                var personExists = service.GetFirst(where);

                if (personExists != null)
                {//encontrou person, validar se é o mesmo cliente.
                    if (personExists.Physical.Id != id || personExists.Legal.Id != id)
                    { errosEntityToBase.Add($"O documento informado {documento} ja possui cadastro."); }
                }


                static Task<(Guid, string)> RecuperarDocId(PessoaDTO pessoa)
                {
                    if (pessoa.Fisica != null)
                    {
                        return Task.FromResult((pessoa.Fisica.Id, pessoa.Fisica.Cpf));
                    }
                    else if (pessoa.Juridica != null)
                    {
                        return Task.FromResult((pessoa.Juridica.Id, pessoa.Juridica.Cnpj));
                    }
                    else
                        return Task.FromResult((Guid.NewGuid(), ""));
                }

                if (errosEntityToBase.Count() > 0)
                { return false; }
                else
                { return true; }
            }
        }
    }
}

