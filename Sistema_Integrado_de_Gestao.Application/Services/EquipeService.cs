using AutoMapper;
using Sistema_Integrado_de_Gestao.Application.Dtos;
using Sistema_Integrado_de_Gestao.Application.Interfaces;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using Sistema_Integrado_de_Gestao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Services
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepository _repository;
        private readonly IMapper _mapper;

        public EquipeService(IEquipeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Equipe> Alterar(Equipe equipeDTO)
        {
            var equipe = _mapper.Map<Equipe>(equipeDTO);
            var equipeAlterada = await _repository.Alterar(equipe);
            return _mapper.Map<Equipe>(equipeAlterada);
        }

        public Task<Equipe> Excluir(int id)
        {
            var equipe = _repository.Excluir(id);
            return equipe;
        }

        public Task<Equipe> Incluir(Equipe equipeDTO)
        {
            var equipe = _mapper.Map<Equipe>(equipeDTO);
            var equipeIncluida = _repository.Incluir(equipe);
            return equipeIncluida;
        }

        public Task<bool> SalveAllAsync()
        {
            var resultado = _repository.SalveAllAsync();
            return resultado;
        }

        public Task<Equipe> SelecionarByPk(int id)
        {
            var equipe = _repository.SelecionarByPk(id);
            return equipe;
        }

        public Task<IEnumerable<Equipe>> SelecionarTodos()
        {
            var equipes = _repository.SelecionarTodos();
            return equipes;
        }
    }
}
