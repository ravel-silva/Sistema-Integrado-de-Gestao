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
        Task<FuncionarioCreateDTO> AlterarPorPrefixo(FuncionarioCreateDTO funcionarioDTO);
        Task<FuncionarioCreateDTO> AlterarPorId(FuncionarioCreateDTO funcionarioDTO);
        Task<FuncionarioCreateDTO> Excluir(int id);
        Task<FuncionarioCreateDTO> SelecionarPorNome(string nome);
        Task<FuncionarioCreateDTO> SelecionarPorId(int id);
        Task<IEnumerable<FuncionarioCreateDTO>> SelecionarTodos();
    }
}
