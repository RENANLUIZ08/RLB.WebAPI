using App.RLB.WebAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace EF.Infrastructure.Services._1_Services
{
    public class DataAnottationValidacoes
    {
        //Validacao de Data Anottation
        public class IdadeMinima : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var pfisica = (PFisica)validationContext.ObjectInstance;
                var idade = DateTime.Now.Year - pfisica.DataNascimento.Year;

                return idade < 18 ? ValidationResult.Success : new ValidationResult("Não é possivel cadastrar menores de idade.");
            }
        }

        public class ValidarCPF : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var pfisica = (PFisica)validationContext.ObjectInstance;

                return new PessoaService().ValidaCPF(pfisica.Cpf) == true ? ValidationResult.Success :
                new ValidationResult("Por favor, verifique seu CPF e tente novamente.");
            }
        }

        public class ValidarCNPJ : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var pjurica = (PJuridica)validationContext.ObjectInstance;

                return new PessoaService().ValidaCNPJ(pjurica.Cnpj) == true ? ValidationResult.Success :
                new ValidationResult("Por favor, verifique seu CNPJ e tente novamente.");
            }
        }
    }
}
