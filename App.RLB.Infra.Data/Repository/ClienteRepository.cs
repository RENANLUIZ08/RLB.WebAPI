using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using App.RLB.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Infra.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Client>, IClienteRepository
    {
        public ClienteRepository(Contexto contexto): base(contexto)
        {

        }
    }
}
