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
            var equipeExistente = _equipeRepository.SelecionarPorPrefixo(equipeDTO.Prefixo);
            DomainExceptionValidation.When(equipeExistente != null, "Já existe uma equipe com esse prefixo.");

            var equipe = _mapper.Map<Equipe>(equipeDTO);
            var equipeIncluida = await _equipeRepository.Incluir(equipe);
            return _mapper.Map<EquipeCreateDTO>(equipeIncluida);
        }
        public async Task<EquipeUpdateDTO> AlterarPorPrefixo(string prefixo, EquipeUpdateDTO equipeDTO)
        {

            var equipeExistente = await _equipeRepository.SelecionarPorPrefixo(prefixo);
            DomainExceptionValidation.When(equipeExistente == null, "Equipe não encontrada.");


            if (equipeDTO.Prefixo != prefixo)
            {
                var equipeComMesmoPrefixo = await _equipeRepository.SelecionarPorPrefixo(equipeDTO.Prefixo);
                DomainExceptionValidation.When(
                    equipeComMesmoPrefixo != null && equipeComMesmoPrefixo.Id != equipeExistente.Id,
                    "Já existe uma equipe com esse prefixo.");
            }


            _mapper.Map(equipeDTO, equipeExistente);


            var equipeAtualizada = await _equipeRepository.AlterarPorPrefixo(equipeExistente);


            return _mapper.Map<EquipeUpdateDTO>(equipeAtualizada);
        }
        public async Task<EquipeUpdateDTO> AlterarPorId(int id, EquipeUpdateDTO equipeDTO)
        {

            var equipeExistente = await _equipeRepository.SelecionarPorId(id);
            DomainExceptionValidation.When(equipeExistente == null, "Equipe não encontrada.");

            // Verificar se o novo prefixo já existe em outra equipe
            var equipeComMesmoPrefixo = await _equipeRepository.SelecionarPorPrefixo(equipeDTO.Prefixo);
            if (equipeComMesmoPrefixo != null && equipeComMesmoPrefixo.Id != id)
            {
                throw new DomainExceptionValidation("Já existe uma equipe com esse prefixo.");
            }

            // Atualizar os dados da entidade
            _mapper.Map(equipeDTO, equipeExistente);

            // Salvar no banco
            var equipeAtualizada = await _equipeRepository.AlterarPorId(equipeExistente);

            return _mapper.Map<EquipeUpdateDTO>(equipeAtualizada);
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
        public async Task<EquipeReadDTO> SelecionarPorId(int id)
        {
            var equipe = await _equipeRepository.SelecionarPorId(id);
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
