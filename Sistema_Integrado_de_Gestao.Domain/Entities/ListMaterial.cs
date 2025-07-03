using Sistema_Integrado_de_Gestao.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    public class ListMaterial
    {
        public int Id { get; set; }
        public int RequisicaoDeMaterialId { get; set; }
        public int MaterialId { get; set; }
        public int Quantidade { get; set; }

        public RequisicaoDeMaterial RequisicaoDeMaterial { get; set; }
        public Material Material { get; set; }

        public ListMaterial(int requisicaoDeMaterialId, int materialId, int quantidade)
        {
            validateDomain(requisicaoDeMaterialId, materialId, quantidade);
        }

        private void validateDomain(int requisicaoDeMaterialId, int materialId, int quantidade)
        {
            DomainExceptionValidation.When(requisicaoDeMaterialId <= 0, "O ID da requisição de material não pode ser menor ou igual a zero.");
            DomainExceptionValidation.When(materialId <= 0, "O ID do material não pode ser menor ou igual a zero.");
            DomainExceptionValidation.When(quantidade <= 0, "A quantidade do material deve ser maior que zero.");
        }

        public void setProperties(int requisicaoDeMaterialId, int materialId, int quantidade)
        {
            RequisicaoDeMaterialId = requisicaoDeMaterialId;
            MaterialId = materialId;
            Quantidade = quantidade;
        }
        public void update(int requisicaoDeMaterialId, int materialId, int quantidade)
        {
            validateDomain(requisicaoDeMaterialId, materialId, quantidade);
        }
    }
}
