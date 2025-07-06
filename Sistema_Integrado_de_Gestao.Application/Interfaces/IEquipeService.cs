using Sistema_Integrado_de_Gestao.Application.Dtos;
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
        Task<EquipeDTO> Incluir(EquipeDTO equipeDTO);
        Task<EquipeDTO> Alterar(EquipeDTO equipeDTO);
        Task<EquipeDTO> Excluir(int id);
        Task<EquipeDTO> SelecionarByPk(int id);
        Task<IEnumerable<EquipeDTO>> SelecionarTodos();
        Task<bool> SalveAllAsync();
    }
}
