using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    internal class ListMaterial
    {
        public int Id { get; set; }
        public int RequisicaoDeMaterialId { get; set; }
        public int MaterialId { get; set; }
        public int Quantidade { get; set; }

        public RequisicaoDeMaterial RequisicaoDeMaterial { get; set; }
        public Material Material { get; set; }
    }
}
