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
        Task<Equipe> AlterarPorPrefixo(Equipe equipe); //ok
        Task<Equipe> AlterarPorId(Equipe equipe); //ok
        Task<Equipe> Excluir(int id);
        Task<Equipe> SelecionarPorPrefixo(string prefixo);
        Task<Equipe> SelecionarPorId(int id); 
        Task<IEnumerable<Equipe>> SelecionarTodos(); //ok
        Task<bool> SalveAllAsync();
        
    }
}
