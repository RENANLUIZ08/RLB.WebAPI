using App.RLB.Domain.Core.Shared.DTO;
using App.RLB.Domain.Core.Shared.Validations.Commands;
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
    public class ClienteDTOValidation : AbstractValidator<ClienteDTO>
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidatePerson(IServiceBase<Person> repository)
        {
            RuleFor(c => c.Pessoa).Custom((pessoa, context) => 
            {
                if (pessoa.Fisica != null)
                {
                    new CommandNewPessoaFisica(repository);
                }
                else if (pessoa.Juridica != null)
                {
                    new CommandNewPessoaJuridica(repository);
                }
                else
                    context.AddFailure("Não foi possivel identificar o tipo de pessoa para o cadastro de cliente.");
            });

        }
    }
}

