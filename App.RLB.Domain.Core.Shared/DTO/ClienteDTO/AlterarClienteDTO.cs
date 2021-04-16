
using App.RLB.Domain.Entity;
using System;

namespace App.RLB.Domain.Core.Shared.DTO.ClienteDTO
{
    public class AlterarClienteDTO : NovoClienteDTO
    {
        public Guid Id { get; set; }

        public static new AlterarClienteDTO MontarDTO(Client model)
        {
            return new AlterarClienteDTO()
            {
                Id = model.Id,
                Pessoa = PessoaDTO.MontarDTO(model.Person)
            };
        }
    }
}
