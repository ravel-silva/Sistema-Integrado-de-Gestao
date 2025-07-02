using Sistema_Integrado_de_Gestao.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    public class Material
    {
        public int Id { get; private set; }
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; private set; }
        public string Unidade { get; private set; }
        public string Status { get; private set; }
        public DateTime DataCriacao { get; private set; } = DateTime.Now;

        // public ICollection<ListMaterial> ListMateriais { get; set; }
        public Material(int codigo, string nome, string descricao, int quantidade, string unidade, string status, DateTime dataCriacao)
        {
            validateDomain(codigo, nome, descricao, quantidade, unidade, status, dataCriacao);
        }
        private void validateDomain(int codigo, string nome, string descricao, int quantidade, string unidade, string status, DateTime dataCriacao)
        {
            DomainExceptionValidation.When(codigo <= 0, "O código do material deve ser maior que zero.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome do material não pode ser vazio.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "A descrição do material não pode ser vazia.");
            DomainExceptionValidation.When(quantidade < 0, "A quantidade do material não pode ser negativa.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(unidade), "A unidade do material não pode ser vazia.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(status), "O status do material não pode ser vazio.");
            DomainExceptionValidation.When(dataCriacao > DateTime.Now && dataCriacao < DateTime.Now, "A Data de Criação não pode ser maior ou menor que a data atual.");
            DomainExceptionValidation.When(dataCriacao == default, "A Data de Criação não pode ser vazia.");
        }

        public void setProperties(int codigo, string nome, string descricao, int quantidade, string unidade, string status, DateTime dataCriacao)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
            Unidade = unidade;
            Status = status;
            DataCriacao = dataCriacao;
        }
        public void update(int codigo, string nome, string descricao, int quantidade, string unidade, string status, DateTime dataCriacao)
        {
            validateDomain(codigo, nome, descricao, quantidade, unidade, status, dataCriacao);
        }
    }
}
