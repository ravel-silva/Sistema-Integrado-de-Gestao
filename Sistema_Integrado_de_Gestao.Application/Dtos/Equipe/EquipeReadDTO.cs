using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Dtos.Equipe
{
    public class EquipeReadDTO
    {
        public int Id { get; set; }
        public string Prefixo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
