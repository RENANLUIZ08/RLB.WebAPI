using App.RLB.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.RLB.WebAPI.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [HiddenInput]
        public Guid Id { get; set; }
        [ForeignKey("PFisica")]
        public Guid? PFisicaId { get; set; }
        public virtual PFisica Fisica { get; set; }
        [ForeignKey("PJuridica")]
        public Guid? PJuridicaId { get; set; }
        public virtual PJuridica Juridica { get; set; }

        public Cliente()
        {
        }

        public Cliente(ClienteDTO dto)
        {
            Id = dto.Id;
            if(dto.Fisica != null)
            {
                Fisica = new PFisica(dto.Fisica);
                PFisicaId = dto.Fisica.Id;
            }
            if (dto.Juridica != null)
            {
                Juridica = new PJuridica(dto.Juridica);
                PJuridicaId = dto.Juridica.Id;
            }
        }
    }
}
