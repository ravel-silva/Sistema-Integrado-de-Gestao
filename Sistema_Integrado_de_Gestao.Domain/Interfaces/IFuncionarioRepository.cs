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
        Task<Funcionario> Incluir(Funcionario funcionario); //ok
        Task<Funcionario> AlterarPorNome(Funcionario funcionario); //ok
        Task<Funcionario> AlterarPorId(Funcionario funcionario); //ok
        Task<Funcionario> Excluir(int id);
        Task<Funcionario> SelecionarPorNome(string nome); //ok
        Task<Funcionario> SelecionarPorId(int id); //ok
        Task<IEnumerable<Funcionario>> SelecionarTodos(); //ok
        
    }
}
