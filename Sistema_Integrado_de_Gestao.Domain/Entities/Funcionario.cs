using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    internal class Funcionario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do funcionario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a matricula do funcionario")]
        [RegularExpression(@"^\d{3,10}$", ErrorMessage = "Matricula precisa ter entre 3 e 10 dígitos")]
        public string Matricula { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public virtual ICollection<EquipeFuncionario> EquipesFuncionarios { get; set; }

    }
}
