using App.RLB.Domain.Core.Shared.DTO;
using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.RLB.Domain.Core.Shared.Validations
{
    public class ContatoDTOValidation : AbstractValidator<ContatoDTO>
    {
        #region Variables
        protected Dictionary<string, string> errosEntityToBase = null;
        #endregion
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage("Por favor, preencha um e-mail valido.");
        }
        protected void ValidateExists(IServiceBase<Contact> service)
        {
            RuleFor(c => c).Must(ValidateExists).WithMessage(string.Join(", ", errosEntityToBase.ToArray()));

            bool ValidateExists(ContatoDTO contatoDTO)
            {
                errosEntityToBase = new Dictionary<string, string>();

                Expression<Func<Contact, bool>> where = (ct) => contatoDTO.Email == ct.Email ||
                contatoDTO.Celular == ct.Celular || contatoDTO.Telefone == ct.Telefone;
                
                var contactExists = service.GetMany(where);

                if(contactExists.Count() > 0)
                {
                    contactExists.ToList().ForEach(ce =>
                    {
                        if ((ce.Celular == contatoDTO.Celular && ce.PessoaId != contatoDTO.Pessoa.Id) && !errosEntityToBase.Any(t => t.Key == "cel"))
                        { errosEntityToBase.Add("cel", "Ja existe um cadastro do número de celular informado."); }

                        if ((ce.Email == contatoDTO.Email && ce.PessoaId != contatoDTO.Pessoa.Id) && !errosEntityToBase.Any(t => t.Key == "email"))
                        { errosEntityToBase.Add("email", "Ja existe um cadastro do e-mail informado."); }

                        if ((ce.Telefone == contatoDTO.Telefone && ce.PessoaId != contatoDTO.Pessoa.Id) && !errosEntityToBase.Any(t => t.Key == "fone"))
                        { errosEntityToBase.Add("fone", "Ja existe um cadastro do telefone informado."); }
                    });
                }

                if (errosEntityToBase.Count() > 0)
                { return false; }
                else
                { return true; }
            }
        }
    }
}

