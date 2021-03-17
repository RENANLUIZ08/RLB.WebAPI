using App.Data.Repositories;
using App.RLB.WebAPI.Data.Repositories;
using App.RLB.WebAPI.DTO;
using App.RLB.WebAPI.Models;
using App.RLB.WebAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.Services
{
    public class ClienteService : IClienteService
    {
        protected readonly IRepositoryBase<Cliente> clienteRepository;

        public ClienteService(IRepositoryBase<Cliente> clienteRepository,
           IRepositoryBase<PFisica> pfisicaRepository, IRepositoryBase<PJuridica> pjuridicaRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public Task<ClienteDTO> Insert(ClienteDTO cliente)
        {
            if (cliente != null)
            {
                if (cliente.Fisica != null)
                { ValidarClienteExistente(cliente.Fisica.Cpf, Guid.Empty); }
                if (cliente.Juridica != null)
                { ValidarClienteExistente(cliente.Juridica.Cnpj, Guid.Empty); }

                clienteRepository.InsertDb(new Cliente(cliente));
                clienteRepository.CommitWork();
                return Task.FromResult(cliente);
            }
            throw new ArgumentNullException(nameof(cliente));
        }

        public Task<ClienteDTO> Edit(ClienteDTO cliente)
        {
            if (cliente != null)
            {
                if (cliente.Fisica != null)
                { ValidarClienteExistente(cliente.Fisica.Cpf, cliente.Id); }
                else if (cliente.Juridica != null)
                { ValidarClienteExistente(cliente.Juridica.Cnpj, cliente.Id); }

                clienteRepository.UpdateDb(new Cliente(cliente));
                clienteRepository.CommitWork();
                return Task.FromResult(cliente);
            }
            throw new ArgumentNullException(nameof(cliente));
        }

        public void Delete(Guid Id)
        {
            var cliente = clienteRepository.AsQueryable().Where(c => c.Id == Id).FirstOrDefault();
 
            if (cliente != null)
            {
                clienteRepository.DeleteDb(cliente);
                clienteRepository.CommitWork();
            }
            throw new ArgumentNullException(nameof(cliente));
        }

        private void ValidarClienteExistente(string documento, Guid? Idcliente)
        {
            Expression<Func<Cliente, bool>> filtroCliente = (fp) => fp.Fisica.Cpf == documento || fp.Juridica.Cnpj == documento;
            var cliente = clienteRepository.GetWhere(filtroCliente);
            if (Idcliente.HasValue? Guid.Empty.Equals(Idcliente): false)
            {//novo cadastro
                if (cliente != null)
                {//encontrou cliente, verificar se é pessoa juridica ou fisica.
                    if (cliente.Fisica != null)
                    { throw new Exception("CPF ja possui cadastro no sistema."); }
                    else if (cliente.Juridica != null)
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
                    if(cliente?.PFisicaId.Value != Idcliente || cliente?.PJuridicaId.Value != Idcliente)
                    { throw new Exception($"O documento informado {documento} ja possui cadastro."); }
                }
            }


        }

        public Task<List<ClienteDTO>> SelectMany()
            => Task.FromResult(clienteRepository.All.Select(c => new ClienteDTO().MontarDTO(c.Id, c.Fisica, c.Juridica)).ToList());

        public Task<ClienteDTO> FindKey(Guid id)
        {
            if(Guid.Empty.Equals(id))
            { throw new Exception("Não foi identificado o valor Id para consulta, tente novamente."); }
            var cliente = clienteRepository.GetOne(id);
            if(cliente == null)
            { throw new Exception("Não foi encontrado nenhum dado pelo valor Id informado."); }

            return Task.FromResult(new ClienteDTO().MontarDTO(cliente.Id, cliente.Fisica, cliente.Juridica));
        }

        //validar permissoes...
    }

}
