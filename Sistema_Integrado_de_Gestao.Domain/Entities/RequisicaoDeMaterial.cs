using Sistema_Integrado_de_Gestao.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    public class RequisicaoDeMaterial
    {
        public int Id { get; set; }
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; }

        public ICollection<ListMaterial> Materiais { get; set; }
        public string Status { get; set; }  // Status da requisição (ex: Ativo, Cancelado, Concluído)
        public DateTime DataDaRequisicao { get; set; } = DateTime.Now; // Data e hora em que a requisição foi feita

        public RequisicaoDeMaterial(
            int equipeId,
            string status,
            DateTime dataDaRequisicao)
        {
            validateDomain(equipeId, status, dataDaRequisicao);
        }

        private void validateDomain(int equipeId,string status, DateTime dataDaRequisicao)
        {
            DomainExceptionValidation.When(equipeId <= 0, "O ID da equipe não pode ser menor ou igual a zero.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(status), "O status não pode ser vazio.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(status), "O status não pode ser vazio.");

            EquipeId = equipeId;
            Status = status;
            DataDaRequisicao = dataDaRequisicao;
        }

        public void update(
            int equipeId,
            string status,
            DateTime dataDaRequisicao)
        {
            validateDomain(equipeId, status, dataDaRequisicao);
        }
    }
}
