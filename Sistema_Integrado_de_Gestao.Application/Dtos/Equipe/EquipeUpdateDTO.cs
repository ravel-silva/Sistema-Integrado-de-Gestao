using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Dtos.Equipe
{
    public class EquipeUpdateDTO
    {
        public int id { get; set; }
        public string Prefixo { get; set; }
        public DateTime DataDeAtualizacao { get; set; } = DateTime.Now;
    }
}
