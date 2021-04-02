using App.RLB.Application.DTO;
using App.RLB.Domain.Entity;
using System;

namespace App.RLB.Application.DTO
{
    public class ClienteDTO : DTOBase
    {
        public PessoaDTO Pessoa { get; set; }
        public ClienteDTO()
        {

        }

        public static ClienteDTO MontarDTO(Client model)
        {
            return new ClienteDTO()
            {
                Id = model.Id,
                Pessoa = PessoaDTO.MontarDTO(model.Person)
            };
        }
    }
}
