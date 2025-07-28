using Sistema_Integrado_de_Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Interfaces
{
    public interface IEquipeRepository
    {
        Task<Equipe> Incluir(Equipe equipe); //ok
        Task<Equipe> Alterar(Equipe equipe);
        Task<Equipe> Excluir(int id);
        Task<Equipe> SelecionarPorPrefixo(string prefixo);
        Task<IEnumerable<Equipe>> SelecionarTodos(); //ok
        Task<bool> SalveAllAsync();
    }
}
