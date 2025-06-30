using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    internal class EquipeFuncionario
    {
        public int Id { get; set; }
        [Required]
        public int equipeId { get; set; }

        public Equipe equipe { get; set; }
        [Required]
        public int funcionarioId { get; set; }

        public Funcionario funcionario { get; set; }

        public DateTime dataEntrada { get; set; } = DateTime.Now;
    }
}
