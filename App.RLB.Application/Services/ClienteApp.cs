using App.RLB.Application.Interfaces;
using App.RLB.Domain.Core.Shared.DTO;
using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Services;
using AutoMapper;

namespace App.RLB.Application.Services
{
    public class ClienteApp : ServiceAppBase<Client, ClienteDTO>, IClienteApp
    {

        public ClienteApp(IMapper iMapper, IClienteService service): base(iMapper, service)
        {

        }
    }
}
