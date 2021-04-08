using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.RLB.Domain.Entity
{
    public class Person : EntityBase
    {
        public virtual IEnumerable<Contact> Contacts { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }

        public Guid? PfisicaId { get; set; }
        public virtual PhysicalPerson Physical { get; set; }

        public Guid? PjuridicaId { get; set; }
        public virtual LegalPerson Legal { get; set; }

    }
}
