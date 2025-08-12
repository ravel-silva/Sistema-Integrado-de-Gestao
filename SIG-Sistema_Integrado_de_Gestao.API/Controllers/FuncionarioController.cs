using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Integrado_de_Gestao.Application.Dtos.Equipe;
using Sistema_Integrado_de_Gestao.Application.Dtos.Funcionario;
using Sistema_Integrado_de_Gestao.Application.Services;
using Sistema_Integrado_de_Gestao.Domain.Validation;

namespace SIG_Sistema_Integrado_de_Gestao.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<FuncionarioCreateDTO>> CadastroDeFuncionario([FromBody] FuncionarioCreateDTO dto)
        {
            try
            {
                var funcionario = await _funcionarioService.Incluir(dto);
                return Ok(funcionario);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { prefixo = dto.Nome, dataDaCriacao = dto.DataCriacao, mensagem = ex.Message });
            }

        }

        [HttpPut("alterarFuncionarioPorNome/{nome}")]
        public async Task<ActionResult<FuncionarioUpdateDTO>> AlterarFuncionarioPorNome(string nome, [FromBody] FuncionarioUpdateDTO dto)
        {
            try
            {
                var funcionario = await _funcionarioService.AlterarPorNome(nome, dto);
                return Ok(funcionario);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { nome = dto.Nome, matricula = dto.Matricula, dataDeAtualizacao = dto.DataDeAtualizacao, mensagem = ex.Message });
            }
        }
        [HttpPut("alterarFuncionarioPorId/{id}")]
        public async Task<ActionResult<FuncionarioUpdateDTO>> AlterarFuncionarioPorId(int id, [FromBody] FuncionarioUpdateDTO dto)
        {
            try
            {
                var funcionario = await _funcionarioService.AlterarPorId(id, dto);
                return Ok(funcionario);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { id = id, nome = dto.Nome, matricula = dto.Matricula, dataDeAtualizacao = dto.DataDeAtualizacao, mensagem = ex.Message });
            }
        }
        [HttpGet("listarFuncionarios")]
        public async Task<ActionResult<IEnumerable<FuncionarioReadDTO>>> SelecionarTodos()
        {
            var funcionarios = await _funcionarioService.SelecionarTodos();
            if (funcionarios == null || !funcionarios.Any())
            {
                return NotFound("Nenhuma equipe encontrada.");
            }
            return Ok(funcionarios);
        }
        [HttpGet("selecionarFuncionarioPorNome/{nome}")]
        public async Task<ActionResult<IEnumerable<EquipeReadDTO>>> SelecionarFuncionarioPorNome(string nome)
        {
            var funcionario = await _funcionarioService.SelecionarPorNome(nome);
            return Ok(funcionario);
        }
        [HttpGet("selecionarFuncionarioPorMatricula/{matricula}")]
        public async Task<ActionResult<IEnumerable<EquipeReadDTO>>> SelecionarFuncionarioPorMatricula(string matricula)
        {
            var funcionario = await _funcionarioService.SelecionarPorMatricula(matricula);
            return Ok(funcionario);
        }
        [HttpGet("selecionarFuncionarioPorId/{id}")]
        public async Task<ActionResult<EquipeReadDTO>> SelecionarFuncionarioPorIdAsync(int id)
        {
            var funcionario = await _funcionarioService.SelecionarPorId(id);
            return Ok(funcionario);
        }

        [HttpDelete("excluirFuncionario/{id}")]
        public async Task<ActionResult<bool>> ExcluirFuncionario(int id)
        {
            try
            {
                var excluiu = await _funcionarioService.Excluir(id);
                return Ok(excluiu);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { id = id, mensagem = ex.Message });
            }
        }
    }
}
