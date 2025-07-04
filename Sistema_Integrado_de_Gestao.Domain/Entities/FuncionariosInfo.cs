using Sistema_Integrado_de_Gestao.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    public class FuncionariosInfo
    {
        public int Id { get; set; }
        public string NomeFuncionario { get; set; }
        public string MatriculaFuncionario { get; set; }

        // public virtual ICollection<Funcionario> Funcionarios { get; set; }

        public FuncionariosInfo(int id, string nomeFuncionario, string matriculaFuncionario)
        {
            validateDomain(id, nomeFuncionario, matriculaFuncionario);
        }

        private void validateDomain(int id, string nomeFuncionario, string matriculaFuncionario)
        {
            DomainExceptionValidation.When(id <= 0, "O ID do funcionário deve ser maior que zero.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeFuncionario), "O nome do funcionário não pode ser vazio.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(matriculaFuncionario), "A matrícula do funcionário não pode ser vazia.");
            DomainExceptionValidation.When(matriculaFuncionario.Length < 3 || matriculaFuncionario.Length > 10, "A matrícula deve ter entre 3 e 10 caracteres.");


            Id = id;
            NomeFuncionario = nomeFuncionario;
            MatriculaFuncionario = matriculaFuncionario;
        }

        public void update(int id, string nomeFuncionario, string matriculaFuncionario)
        {
            validateDomain(id, nomeFuncionario, matriculaFuncionario);

        }
    }
}
