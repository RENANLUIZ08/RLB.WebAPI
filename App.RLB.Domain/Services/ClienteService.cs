using App.RLB.Domain.Entity;
using App.RLB.Domain.Interface.Repositories;
using App.RLB.Domain.Interface.Services;
using System;
using System.Linq.Expressions;

namespace App.RLB.Domain.Services
{
    public class ClienteService : ServiceBase<Client>, IClienteService
    {
        public ClienteService(IClienteRepository repository)
            : base (repository)
        {

        }
        public void ValidarClienteExistente(string documento, Guid? Idcliente)
        {
            RepositoryBase

            Expression<Func<Client, bool>> filtroCliente = (fp) => fp.Person.Physical.Cpf == documento || fp.Person.Legal.Cnpj == documento;
            var cliente = repository.GetFirst(filtroCliente);
            //IRepositoryBase<Client> repository = new  // repository.GetFirst(filtroCliente);
            if (Idcliente.HasValue? Guid.Empty.Equals(Idcliente): false)
            {//novo cadastro
                if (cliente != null)
                {//encontrou cliente, verificar se é pessoa juridica ou fisica.
                    if (cliente.Person.Physical != null)
                    { throw new Exception("CPF ja possui cadastro no sistema."); }
                    else if (cliente.Person.Legal != null)
                    { throw new Exception("CNPJ ja possui cadastro no sistema."); }
                    else
                    {
                        throw new NullReferenceException("Nao foi identificado o tipo de cadastro no sistema pelo documento informado," +
                          " tente novamente. Caso persista o erro, entre em contato com o suporte");
                    }
                }//Ok, pode continuar.
            }
            else
            {//cadastro existente
                if (cliente != null)
                {//encontrou cliente, validar se é o mesmo cliente.
                    if(cliente.Person.Physical.Id != Idcliente || cliente.Person.Legal.Id != Idcliente)
                    { throw new Exception($"O documento informado {documento} ja possui cadastro."); }
                }
            }


        }

    }

}
