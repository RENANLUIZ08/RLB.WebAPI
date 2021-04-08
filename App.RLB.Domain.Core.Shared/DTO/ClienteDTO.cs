
using App.RLB.Domain.Entity;

namespace App.RLB.Domain.Core.Shared.DTO
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
