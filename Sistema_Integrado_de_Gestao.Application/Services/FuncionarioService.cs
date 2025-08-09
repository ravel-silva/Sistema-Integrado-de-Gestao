using AutoMapper;
using Sistema_Integrado_de_Gestao.Application.Dtos.Equipe;
using Sistema_Integrado_de_Gestao.Application.Dtos.Funcionario;
using Sistema_Integrado_de_Gestao.Application.Interfaces;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using Sistema_Integrado_de_Gestao.Domain.Interfaces;
using Sistema_Integrado_de_Gestao.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Application.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }
        public async Task<FuncionarioCreateDTO> Incluir(FuncionarioCreateDTO funcionarioDTO)
        {
            var funcionarioExistente = await _funcionarioRepository.SelecionarPorNome(funcionarioDTO.Nome);
            DomainExceptionValidation.When(funcionarioExistente != null, "Já existe um funcionário cadastrado com esse nome.");

            var funcionario = _mapper.Map<Funcionario>(funcionarioDTO);
            var funcionarioIncluido = await _funcionarioRepository.Incluir(funcionario);
            return _mapper.Map<FuncionarioCreateDTO>(funcionarioIncluido);

        }
        public async Task<FuncionarioUpdateDTO> AlterarPorId(int id, FuncionarioUpdateDTO funcionarioDTO)
        {
            var funcionarioComMesmoNome = await _funcionarioRepository.SelecionarPorId(id);
            DomainExceptionValidation.When(funcionarioComMesmoNome == null, "Funcionário não encontrado.");

            var funcionarioExistente = await _funcionarioRepository.SelecionarPorNome(funcionarioDTO.Nome);
            if (funcionarioExistente != null && funcionarioExistente.Id != id)
            {
                throw new DomainExceptionValidation("Já existe um funcionário cadastrado com esse nome.");
            }
            _mapper.Map(funcionarioDTO, funcionarioComMesmoNome);
            var funcionarioAtualizado = await _funcionarioRepository.AlterarPorId(funcionarioComMesmoNome);
            return _mapper.Map<FuncionarioUpdateDTO>(funcionarioAtualizado);


        }
        public async Task<FuncionarioUpdateDTO> AlterarPorNome(string nome, FuncionarioUpdateDTO funcionarioDTO)
        {
            var funcionarioComMesmoNome = await _funcionarioRepository.SelecionarPorNome(nome);
            DomainExceptionValidation.When(funcionarioComMesmoNome == null, "Funcionário não encontrado.");

            if (funcionarioComMesmoNome.Nome != funcionarioDTO.Nome)
            {
                var funcionarioExistente = await _funcionarioRepository.SelecionarPorNome(funcionarioDTO.Nome);
                DomainExceptionValidation.When(
                    funcionarioExistente != null && funcionarioExistente.Id != funcionarioComMesmoNome.Id,
                    "Já existe um funcionário cadastrado com esse nome.");
            }
            _mapper.Map(funcionarioDTO, funcionarioComMesmoNome);
            var funcionarioAtualizado = await _funcionarioRepository.AlterarPorNome(funcionarioComMesmoNome);
            return _mapper.Map<FuncionarioUpdateDTO>(funcionarioAtualizado);
        }
        public async Task<bool> Excluir(int id)
        {
            var funcionarioExistente = await _funcionarioRepository.SelecionarPorId(id);
            DomainExceptionValidation.When(funcionarioExistente == null, "Funcionário não encontrado.");
            var funcionarioExcluido = await _funcionarioRepository.Excluir(id);
            return true;
        }
        public async Task<FuncionarioReadDTO> SelecionarPorId(int id)
        {
            DomainExceptionValidation.When(id == null, "Funcionário não encontrado.");
            var funcionario = await _funcionarioRepository.SelecionarPorId(id);
            return _mapper.Map<FuncionarioReadDTO>(funcionario);
        }
        public async Task<FuncionarioReadDTO> SelecionarPorNome(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome não pode ser vazio.");
            var funcionario = await _funcionarioRepository.SelecionarPorNome(nome);
            DomainExceptionValidation.When(funcionario == null, "Funcionário não encontrado.");
            return _mapper.Map<FuncionarioReadDTO>(funcionario);
        }
        public async Task<IEnumerable<FuncionarioReadDTO>> SelecionarTodos()
        {
            DomainExceptionValidation.When(_funcionarioRepository == null, "Serviço de funcionário não pode ser nulo.");
            var funcionarios = await _funcionarioRepository.SelecionarTodos();  
            DomainExceptionValidation.When(funcionarios == null || !funcionarios.Any(), "Nenhum funcionário encontrado.");
            var ListaDefuncionarios = _mapper.Map<IEnumerable<FuncionarioReadDTO>>(funcionarios);
            return ListaDefuncionarios.ToList();

       }

    }
}
