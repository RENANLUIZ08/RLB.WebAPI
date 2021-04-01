﻿using App.RLB.Application.DTO;
using App.RLB.Domain.Entity;
using System;

namespace App.RLB.Application.DTO
{
    public class ClienteDTO : DTOBase
    {
        public PFisicaDTO Fisica { get; set; }
        public PJuridicaDTO Juridica { get; set; }
        public ClienteDTO()
        {

        }

        public static ClienteDTO MontarDTO(Client model)
        {
            return new ClienteDTO()
            {
                Id = model.Id,
                Fisica = model.Fisica != null ? PFisicaDTO.MontarDTO(model.Fisica) : null,
                Juridica = model.Juridica != null ? PJuridicaDTO.MontarDTO(model.Juridica) : null
            };
        }
    }
}
