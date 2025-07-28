using Microsoft.AspNetCore.Mvc;
using Sistema_Integrado_de_Gestao.Application.Dtos.Equipe;
using Sistema_Integrado_de_Gestao.Application.Services;
using Sistema_Integrado_de_Gestao.Domain.Validation;

namespace SIG_Sistema_Integrado_de_Gestao.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipeController : ControllerBase
    {
        private readonly EquipeService _equipeService;

        public EquipeController(EquipeService equipeService)
        {
            _equipeService = equipeService;
        }
        [HttpPost("registrar")]
        public async Task<ActionResult<EquipeCreateDTO>> CadastroDeEquipe([FromBody] EquipeCreateDTO dto)
        {
            try
            {
                var equipe = await _equipeService.Incluir(dto);
                return Ok(equipe);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { prefixo = dto.Prefixo, dataDaCriacao = dto.DataCriacao, mensagem = ex.Message });
            }

        }


        [HttpPut("alterarEquipePorPrefixo/{prefixo}")]
        public async Task<ActionResult<EquipeUpdateDTO>> AlterarEquipePorPrefixo(string prefixo, [FromBody] EquipeUpdateDTO dto)
        {
            try
            {
                var equipe = await _equipeService.AlterarPorPrefixo(prefixo, dto);
                return Ok(equipe);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { prefixo = dto.Prefixo, dataDeAtualizacao = dto.DataDeAtualizacao, mensagem = ex.Message });
            }
        }
        [HttpPut("aterarEquipePorId/{id}")]
        public async Task<ActionResult<EquipeUpdateDTO>> AlterarEquipePorId(int id, [FromBody] EquipeUpdateDTO dto)
        {
            try
            {
                var equipe = await _equipeService.AlterarPorId(id, dto);
                return Ok(equipe);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { id = id, dataDeAtualizacao = dto.DataDeAtualizacao, mensagem = ex.Message });
            }
        }
        [HttpGet("listarEquipes")]
        public async Task<ActionResult<IEnumerable<EquipeReadDTO>>> SelecionarTodos()
        {
            try
            {
                var equipes = await _equipeService.SelecionarTodos();
                return Ok(equipes);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { mensagem = ex.Message });

            }
        }
        [HttpGet("selecionarEquipePorPrefixo/{prefixo}")]
        public async Task<ActionResult<IEnumerable<EquipeReadDTO>>> SelecionarEquipePorPrefixo(string prefixo)
        {
            try
            {
                var equipe = await _equipeService.SelecionarPorPrefixo(prefixo);
                return Ok(equipe);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { prefixo = prefixo, mensagem = ex.Message });
            }
        }
        [HttpGet("selecionarEquipePorId/{id}")]
        public async Task<ActionResult<EquipeReadDTO>> SelecionarEquipePorId(int id)
        {
            try
            {
                var equipe = await _equipeService.SelecionarPorId(id);
                return Ok(equipe);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { id = id, mensagem = ex.Message });
            }
        }
        [HttpDelete("excluirEquipe/{id}")]
        public async Task<ActionResult<EquipeCreateDTO>> Excluir(int id)
        {
            try
            {
                var equipe = await _equipeService.Excluir(id);
                return Ok(equipe);
            }
            catch (DomainExceptionValidation ex)
            {
                return Conflict(new { id = id, mensagem = ex.Message });
            }
        }
    }
}
