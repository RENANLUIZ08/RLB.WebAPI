using App.RLB.Domain.Core.Shared.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace App.RLB.Domain.Core.Shared.Validations
{
    public class EnderecoDTOValidation : AbstractValidator<EnderecoDTO>
    {
        #region Variables
        protected List<string> errosEntityToBase = null;
        #endregion
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateEndereco()
        {
            RuleFor(c => c.Logradouro).MaximumLength(100).WithMessage("É permitido até 100 caracteres no campo logradouro.");
        }
    }
}

