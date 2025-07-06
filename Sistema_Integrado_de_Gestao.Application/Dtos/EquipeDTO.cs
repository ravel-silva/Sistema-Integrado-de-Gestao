using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Dtos
{
    public class EquipeDTO
    {
        public string Prefixo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
