using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Dtos.Funcionario
{
    public class FuncionarioReadDTO
    {
        public int Id { get;  set; }
        public string Nome { get;  set; }
        public string Matricula { get;  set; }
        public DateTime DataCriacao { get;  set; } = DateTime.Now;
    }
}
