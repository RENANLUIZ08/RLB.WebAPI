using App.RLB.Domain.Core.Shared.DTO;
using App.RLB.Domain.Core.Shared.Validations.Commands;
using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using FluentValidation;
using System;

namespace App.RLB.Domain.Core.Shared.Validations
{
    public class NewClienteDTOValidator : AbstractValidator<ClienteDTO>
    {
        public NewClienteDTOValidator()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty);

            //RuleFor(c => c.Pessoa).Custom((pessoa, context) =>
            //{
            //    if (pessoa.Fisica != null)
            //    {
            //        new CommandNewPessoaFisica(service);
            //    }
            //    else if (pessoa.Juridica != null)
            //    {
            //        new CommandNewPessoaJuridica(service);
            //    }
            //    else
            //        context.AddFailure("Não foi possivel identificar o tipo de pessoa para o cadastro de cliente.");
            //});
        }
    }
}

