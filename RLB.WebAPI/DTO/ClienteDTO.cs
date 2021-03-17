using App.RLB.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.DTO
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }
        public PFisicaDTO Fisica { get; set; }
        public PJuridicaDTO Juridica { get; set; }
        public ClienteDTO()
        {

        }

        public ClienteDTO(Guid id, PFisica pFisica = null, PJuridica pJuridica = null)
        {
            Id = id;
            if (pFisica != null)
            {
                Fisica = new PFisicaDTO().MontarDTO(pFisica);
            }
            if (pJuridica != null)
            {
                Juridica = new PJuridicaDTO().MontarDTO(pJuridica);
            }
        }

        public ClienteDTO MontarDTO(Guid id, PFisica pFisica, PJuridica pJuridica)
        {
            ClienteDTO clienteDTO = null;
            if(pFisica != null && pJuridica != null)
            { clienteDTO = new ClienteDTO(id, pFisica, pJuridica); }
            else if(pFisica != null)
            { clienteDTO = new ClienteDTO(id, pFisica: pFisica); }
            else if (pJuridica != null)
            { clienteDTO = new ClienteDTO(id, pJuridica: pJuridica);  }

            return clienteDTO;
        }
    }
}
