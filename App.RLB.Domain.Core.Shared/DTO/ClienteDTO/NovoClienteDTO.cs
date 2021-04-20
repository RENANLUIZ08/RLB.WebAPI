
using App.RLB.Domain.Entity;

namespace App.RLB.Domain.Core.Shared.DTO.ClienteDTO
{
    public class NovoClienteDTO
    {
        public PessoaDTO Pessoa { get; set; }
        public NovoClienteDTO()
        {

        }

        public static NovoClienteDTO MontarDTO(Client model)
        {
            return new NovoClienteDTO()
            {
                Id = model.Id,
                Pessoa = PessoaDTO.MontarDTO(model.Person)
            };
        }
    }
}
