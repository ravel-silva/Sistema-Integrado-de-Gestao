using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Dtos.Funcionario
{
    public class FuncionarioCreateDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A matrícula é obrigatória")]
        [MinLength(3, ErrorMessage = "A matrícula deve ter no mínimo 3 caracteres.")]
        public string Matricula { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
