using AutoMapper;
using Sistema_Integrado_de_Gestao.Application.Dtos.Equipe;
using Sistema_Integrado_de_Gestao.Application.Interfaces;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using Sistema_Integrado_de_Gestao.Domain.Interfaces;
using Sistema_Integrado_de_Gestao.Domain.Validation;

namespace Sistema_Integrado_de_Gestao.Application.Services
{
    public class EquipeService : IEquipeService
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly IMapper _mapper;

        public EquipeService(IEquipeRepository repository, IMapper mapper)
        {
            _equipeRepository = repository;
            _mapper = mapper;
        }

        public async Task<EquipeCreateDTO> Incluir(EquipeCreateDTO equipeDTO)
        {
            var verificarExistente = _equipeRepository.SelecionarPorPrefixo(equipeDTO.Prefixo);
            DomainExceptionValidation.When(verificarExistente != null, "Já existe uma equipe com esse prefixo.");

            var equipe = _mapper.Map<Equipe>(equipeDTO);
            var equipeIncluida = await _equipeRepository.Incluir(equipe);
            return _mapper.Map<EquipeCreateDTO>(equipeIncluida);
        }
        public async Task<EquipeCreateDTO> Alterar(EquipeCreateDTO equipeDTO)
        {
            var equipe = _mapper.Map<Equipe>(equipeDTO);
            var equipeAlterada = await _equipeRepository.Alterar(equipe);
            return _mapper.Map<EquipeCreateDTO>(equipeAlterada);
        }

        public async Task<EquipeCreateDTO> Excluir(int id)
        {
            var equipe = await _equipeRepository.Excluir(id);
            return _mapper.Map<EquipeCreateDTO>(equipe);
        }


        public Task<bool> SalveAllAsync()
        {
            var resultado = _equipeRepository.SalveAllAsync();
            return resultado;
        }

        public async Task<EquipeReadDTO> SelecionarPorPrefixo(string prefixo)
        {
            var equipe = await _equipeRepository.SelecionarPorPrefixo(prefixo);
            return _mapper.Map<EquipeReadDTO>(equipe);
        }

        public async Task<IEnumerable<EquipeReadDTO>> SelecionarTodos()
        {   
            var equipes = await _equipeRepository.SelecionarTodos();
            var listaDeEquipes = _mapper.Map<IEnumerable<EquipeReadDTO>>(equipes);
            return listaDeEquipes.ToList();
        }

    }
}
