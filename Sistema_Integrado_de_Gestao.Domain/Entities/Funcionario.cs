using Sistema_Integrado_de_Gestao.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        //  public virtual ICollection<EquipeFuncionario> EquipesFuncionarios { get; set; }

        public Funcionario(
            string nome,
            string matricula,
            DateTime dataCriacao)
        {
            validateDomain(nome, matricula, dataCriacao);
        }

        public void validateDomain(string nome, string matricula, DateTime dataCriacao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome do funcionário não pode ser vazio.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(matricula), "A matrícula do funcionário não pode ser vazia.");
            DomainExceptionValidation.When(matricula.Length < 3 || matricula.Length > 10, "A matrícula deve ter entre 3 e 10 caracteres.");
            DomainExceptionValidation.When(dataCriacao == default, "A Data de Criação não pode ser vazia.");
        }
        public void SetProperties(
            string nome,
            string matricula,
            DateTime dataCriacao)
        {
            Nome = nome;
            Matricula = matricula;
            DataCriacao = dataCriacao;
        }
        public void update(string nome, string matricula, DateTime dataCriacao)
        {
            validateDomain(nome, matricula, dataCriacao);
        }
    }
}
