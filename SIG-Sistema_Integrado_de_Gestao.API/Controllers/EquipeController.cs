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
            var equipes = await _equipeService.SelecionarTodos();
            if (equipes == null || !equipes.Any())
            {
                return NotFound("Nenhuma equipe encontrada.");
            }
            return Ok(equipes);
        }
        [HttpGet("selecionarEquipePorPrefixo/{prefixo}")]
        public async Task<ActionResult<IEnumerable<EquipeReadDTO>>> SelecionarEquipePorPrefixo(string prefixo)
        {
            var equipe = await _equipeService.SelecionarPorPrefixo(prefixo);
            return Ok(equipe);
        }
        [HttpGet("selecionarEquipePorId/{id}")]
        public async Task<ActionResult<EquipeReadDTO>> SelecionarEquipePorIdAsync(int id)
        {
            var equipe = await _equipeService.SelecionarPorId(id);
            return Ok(equipe);
        }
    }
}
