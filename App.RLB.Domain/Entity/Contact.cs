using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.RLB.Domain.Entity
{
    public class Contact : EntityBase
    {
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public Guid PessoaId { get; set; }
        public virtual Person Pessoa { get; set; }

        public string Email { get; set; }
    }
   
}
