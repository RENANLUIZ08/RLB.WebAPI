using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.RLB.Domain.Entity
{
    [Table("Cadastro.Pessoas")]
    public class Person : EntityBase
    {
        public virtual IEnumerable<Contact> Contacts { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }

        [ForeignKey("PFisica")]
        public Guid? PfisicaId { get; set; }
        public virtual PhysicalPerson PFisica { get; set; }

        [ForeignKey("PJuridica")]
        public Guid? PjuridicaId { get; set; }
        public virtual LegalPerson PJuridica { get; set; }

    }
}
