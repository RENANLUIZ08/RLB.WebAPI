using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.RLB.Domain.Entity
{
    public class LegalPerson : EntityBase
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string Im { get; set; }
        public string Proprietario { get; set; }
        public Guid PessoaId { get; set; }
        public virtual Person Pessoa { get; set; }
    }
}
