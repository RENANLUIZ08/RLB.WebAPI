using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.RLB.Domain.Entity
{
    [Table("Cadastro.Enderecos")]
    public class Address : EntityBase
    {
        [MaxLength(100)]
        [MinLength(10, ErrorMessage = "O nome da Rua/Avenida deve conter no mínimo 10 caractéres.")]
        [Required(ErrorMessage = "Informe o nome da Rua/Avenida para o cadastro.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Informe o número do seu endereço.")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Informe o bairro do seu endereço.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Informe o cep do seu endereço.")]
        public string Cep { get; set; }
        [ForeignKey("Pessoa")]
        public Guid PessoaId { get; set; }
        public virtual Person Pessoa { get; set; }
    }
}
