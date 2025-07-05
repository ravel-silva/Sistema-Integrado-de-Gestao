using Sistema_Integrado_de_Gestao.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    public class EquipeFuncionario
    {
        public int Id { get; set; }
        public int EquipeId { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime dataEntrada { get; set; } = DateTime.Now;
        public Equipe equipe { get; set; }
        public Funcionario funcionario { get; set; }

        public EquipeFuncionario(
            int equipeId,
            int funcionarioId,
            DateTime dataEntrada)
        {
            validateDomain(equipeId, funcionarioId, dataEntrada);
        }

        private void validateDomain(int idEquipe, int idFuncionario, DateTime dataDeEntrada)
        {
            DomainExceptionValidation.When(idEquipe <= 0, "O ID da equipe deve ser maior que zero.");
            DomainExceptionValidation.When(idFuncionario <= 0, "O ID do funcionário deve ser maior que zero.");
            DomainExceptionValidation.When(dataDeEntrada > DateTime.Now, "A Data de Entrada não pode ser maior que a data atual.");
            DomainExceptionValidation.When(dataDeEntrada == default, "A Data de Entrada não pode ser vazia.");

            EquipeId = idEquipe;
            FuncionarioId = idFuncionario;
            dataEntrada = dataDeEntrada;
        }

        public void update(int equipeId, int funcionarioId, DateTime dataEntrada)
        {
            validateDomain(equipeId, funcionarioId, dataEntrada);
        }

    }
}
