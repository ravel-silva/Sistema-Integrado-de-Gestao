using Sistema_Integrado_de_Gestao.Application.Dtos.Funcionario;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Interfaces
{
    public interface IFuncionarioService
    {
        Task<FuncionarioCreateDTO> Incluir(FuncionarioCreateDTO funcionarioDTO); 
        Task<FuncionarioUpdateDTO> AlterarPorNome(string nome, FuncionarioUpdateDTO funcionarioDTO);
        Task<FuncionarioUpdateDTO> AlterarPorId(int id,FuncionarioUpdateDTO funcionarioDTO);
        Task<bool> Excluir(int id);
        Task<FuncionarioReadDTO> SelecionarPorNome(string nome);
        Task<FuncionarioReadDTO> SelecionarPorId(int id);
        Task<IEnumerable<FuncionarioReadDTO>> SelecionarTodos();
        Task<FuncionarioReadDTO> SelecionarPorMatricula(string matricula);
    }
}
