using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.RLB.Domain.Entity
{
    public class Client : EntityBase
    {
        public Guid PessoaId { get; set; }
        public virtual Person Person { get; set; }

    }
}
