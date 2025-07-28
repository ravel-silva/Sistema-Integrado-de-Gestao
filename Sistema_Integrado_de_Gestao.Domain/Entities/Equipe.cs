using Sistema_Integrado_de_Gestao.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    public class Equipe
    {
        public int Id { get; private set; }
        
        public string Prefixo { get; private set; } = string.Empty;
        public DateTime DataCriacao { get; private set; } = DateTime.Now;

        public virtual ICollection<EquipeFuncionario> EquipesFuncionarios { get; set; }
        public virtual ICollection<RequisicaoDeMaterial> RequisicoesDeMaterial { get; set; }

        public Equipe(
            string prefixo,
            DateTime dataCriacao)
        {
            validateDomain(prefixo, dataCriacao);
        }

        private void validateDomain(string prefixo, DateTime dataCriacao, bool validarDataCriacao = false)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(prefixo), "O Prefixo não pode ser vazio.");
            DomainExceptionValidation.When(prefixo.Length < 6, "O Prefixo deve ter no mínimo 6 caracteres.");
            DomainExceptionValidation.When(prefixo.Contains(" "), "O Prefixo não pode conter espaços em branco.");
            if (validarDataCriacao)
            {
            DomainExceptionValidation.When(dataCriacao.Date != DateTime.Today, "A Data de Criação deve ser a data atual.");
            }
            
            Prefixo = prefixo;
            DataCriacao = dataCriacao;
        }

      
        public void update(string prefixo, DateTime dataCriacao)
        {
            validateDomain(prefixo, dataCriacao);
        }
    }
}
