using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.RLB.Domain.Entity
{
    [Table("Cliente")]
    public class Client : EntityBase
    {
        [ForeignKey("PFisica")]
        public Guid? PFisicaId { get; set; }
        public virtual PhysicalPerson Fisica { get; set; }
        [ForeignKey("PJuridica")]
        public Guid? PJuridicaId { get; set; }
        public virtual LegalPerson Juridica { get; set; }
    }
}
