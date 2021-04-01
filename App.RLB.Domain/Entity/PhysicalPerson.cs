using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static App.RLB.Domain.Entity.DataAnottationsValidations.DataAnottationValidacoes;

namespace App.RLB.Domain.Entity
{
    [Table("Cadastro.PessoaFisica")]
    public class PhysicalPerson : EntityBase
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Informar nome completo para o cadastro")]
        public string Nome { get; set; }
        [ValidarCPF]
        public string Cpf { get; set; }
        [MaxLength(12)]
        public string Rg { get; set; }
        [IdadeMinima]
        public DateTime DataNascimento { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public virtual Person Pessoa { get; set; }
    }
}
