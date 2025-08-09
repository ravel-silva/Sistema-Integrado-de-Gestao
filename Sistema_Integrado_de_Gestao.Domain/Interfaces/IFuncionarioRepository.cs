using Sistema_Integrado_de_Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario> Incluir(Funcionario funcionario);
        Task<Funcionario> AlterarPorPrefixo(Funcionario funcionario);
        Task<Funcionario> AlterarPorId(Funcionario funcionario);
        Task<Funcionario> Excluir(int id);
        Task<Funcionario> SelecionarPorNome(string nome);   
        Task<Funcionario> SelecionarPorId(int id);
        Task<IEnumerable<Funcionario>> SelecionarTodos();
    }
}
