using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.RLB.Domain.Entity
{
    [Table("Cadastro.Contatos")]
    public class Contact : EntityBase
    {
        [DisplayName("Telefone Fixo")]
        [MaxLength(12)]
        public string Telefone { get; set; }
        [DisplayName("Telefone Celular")]
        [MaxLength(13)]
        public string Celular { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public virtual Person Pessoa { get; set; }
    }
   
}
