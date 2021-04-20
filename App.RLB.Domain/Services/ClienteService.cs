using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface;
using App.RLB.Domain.Interface.Repositories;
using App.RLB.Domain.Interface.Services;
using System;
using System.Linq.Expressions;

namespace App.RLB.Domain.Services
{
    public class ClienteService : ServiceBase<Client>, IClienteService
    {
        public ClienteService(IRepositoryBase<Client> repository)
            : base (repository)
        {

        }


    }

}
