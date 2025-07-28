using Sistema_Integrado_de_Gestao.Application.Dtos.Equipe;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Interfaces
{
    public interface IEquipeService
    {
        Task<EquipeCreateDTO> Incluir(EquipeCreateDTO equipeDTO); //ok
        Task<EquipeUpdateDTO> AlterarPorPrefixo(string prefixo, EquipeUpdateDTO equipeDTO); //ok
        Task<EquipeUpdateDTO> AlterarPorId (int id, EquipeUpdateDTO equipeDTO); //ok
        Task<EquipeCreateDTO> Excluir(int id);
        Task<EquipeReadDTO> SelecionarPorPrefixo(string prefixo); //ok
        Task<EquipeReadDTO> SelecionarPorId(int id); //ok
        Task<IEnumerable<EquipeReadDTO>> SelecionarTodos(); //ok
        Task<bool> SalveAllAsync();
    }
}
