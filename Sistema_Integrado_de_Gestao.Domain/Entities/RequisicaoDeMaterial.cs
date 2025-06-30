using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    internal class RequisicaoDeMaterial
    {
        public int Id { get; set; }
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; }

        public ICollection<ListMaterial> Materiais { get; set; }
        public string Status { get; set; }  // Status da requisição (ex: Ativo, Cancelado, Concluído)
        public DateTime DateTime { get; set; } = DateTime.Now; // Data e hora em que a requisição foi feita
    }
}
