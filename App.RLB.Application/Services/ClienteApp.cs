using App.RLB.Application.DTO;
using App.RLB.Application.Interfaces;
using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Application.Services
{
    public class ClienteApp : ServiceAppBase<Client, ClienteDTO>, IClienteApp
    {

        public ClienteApp(IMapper iMapper, IClienteService service): base(iMapper, service)
        {

        }
    }
}
