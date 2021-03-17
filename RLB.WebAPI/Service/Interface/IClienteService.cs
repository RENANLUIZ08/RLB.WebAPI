using App.RLB.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.Services.Interface
{
    public interface IClienteService
    {
        Task<ClienteDTO> Insert(ClienteDTO cliente);
        Task<ClienteDTO> Edit(ClienteDTO cliente);
        void Delete(Guid Id);
        Task<List<ClienteDTO>> SelectMany();
        Task<ClienteDTO> FindKey(Guid id);
        //bool PodeExcluirCliente(Cliente cliente);
    }
}
