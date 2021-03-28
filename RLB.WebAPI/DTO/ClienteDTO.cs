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

        public static ClienteDTO MontarDTO(Cliente model)
        {
            return new ClienteDTO()
            {
                Id = model.Id,
                Fisica = model.Fisica != null? PFisicaDTO.MontarDTO(model.Fisica) : null,
                Juridica = model.Juridica != null? PJuridicaDTO.MontarDTO(model.Juridica): null
            };
        }
    }
}
