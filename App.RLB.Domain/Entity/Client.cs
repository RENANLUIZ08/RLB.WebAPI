using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.RLB.Domain.Entity
{
    [Table("Cliente")]
    public class Client : EntityBase
    {
        [ForeignKey("Person")]
        public Guid PessoaId { get; set; }
        public virtual Person Person { get; set; }
    }
}
