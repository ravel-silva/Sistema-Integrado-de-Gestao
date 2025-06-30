using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    internal class FuncionariosInfo
    {
        public int Id { get; set; }
        public string NomeFuncionario { get; set; }
        public string MatriculaFuncionario { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
