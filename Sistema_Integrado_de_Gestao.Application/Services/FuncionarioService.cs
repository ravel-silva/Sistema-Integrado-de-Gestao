using Sistema_Integrado_de_Gestao.Application.Dtos.Funcionario;
using Sistema_Integrado_de_Gestao.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        public Task<FuncionarioCreateDTO> AlterarPorId(FuncionarioCreateDTO funcionarioDTO)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioCreateDTO> AlterarPorPrefixo(FuncionarioCreateDTO funcionarioDTO)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioCreateDTO> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioCreateDTO> Incluir(FuncionarioCreateDTO funcionarioDTO)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioCreateDTO> SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioCreateDTO> SelecionarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FuncionarioCreateDTO>> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
