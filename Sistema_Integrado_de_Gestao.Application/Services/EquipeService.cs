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

        public async Task<EquipeDTO> Incluir(EquipeDTO equipeDTO)
        {
            var equipe = _mapper.Map<Equipe>(equipeDTO);
            var equipeIncluida = await _repository.Incluir(equipe);
            return _mapper.Map<EquipeDTO>(equipeIncluida);
        }
        public async Task<EquipeDTO> Alterar(EquipeDTO equipeDTO)
        {
            var equipe = _mapper.Map<Equipe>(equipeDTO);
            var equipeAlterada = await _repository.Alterar(equipe);
            return _mapper.Map<EquipeDTO>(equipeAlterada);
        }

        public async Task<EquipeDTO> Excluir(int id)
        {
            var equipe = await _repository.Excluir(id);
            return _mapper.Map<EquipeDTO>(equipe);
        }


        public Task<bool> SalveAllAsync()
        {
            var resultado = _repository.SalveAllAsync();
            return resultado;
        }

        public async Task<EquipeDTO> SelecionarByPk(int id)
        {
            var equipe = await _repository.SelecionarByPk(id);
            return _mapper.Map<EquipeDTO>(equipe);
        }

        public async Task<IEnumerable<EquipeDTO>> SelecionarTodos()
        {   
            var equipes = await _repository.SelecionarTodos();
            var listaDeEquipes = _mapper.Map<IEnumerable<EquipeDTO>>(equipes);
            return listaDeEquipes;
        }

    }
}
