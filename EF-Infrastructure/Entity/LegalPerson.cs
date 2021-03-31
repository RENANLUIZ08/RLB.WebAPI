using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static App.Domain.Services.DataAnottationValidacoes;

namespace App.RLB.Domain.Entity
{
    [Table("Cadastro.PessoaJuridica")]
    public class LegalPerson : EntityBase
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Informar a Razão Social para o cadastro")]
        public string RazaoSocial { get; set; }
        [ValidarCNPJ]
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string Im { get; set; }
        public string Proprietario { get; set; }

        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public virtual Person Pessoa { get; set; }
    }
}
