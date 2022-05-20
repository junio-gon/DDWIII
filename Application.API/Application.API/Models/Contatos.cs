using System;
using System.ComponentModel.DataAnnotations;

namespace Application.API.Models
{
    public class Contatos : Base
    {
        //nome, email, telefone, nascimento, dataCadastro, dataAlteracao, isActive
        [StringLength(60, ErrorMessage = "O {0} precisa ter entre {2} e {1} caracteres",
            MinimumLength = 5)]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        public string telefone { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool IsActive { get; set; }
    }
}
