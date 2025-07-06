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
        Task<Equipe> Incluir(Equipe equipeDTO);
        Task<Equipe> Alterar(Equipe equipeDTO);
        Task<Equipe> Excluir(int id);
        Task<Equipe> SelecionarByPk(int id);
        Task<IEnumerable<Equipe>> SelecionarTodos();
        Task<bool> SalveAllAsync();
    }
}
