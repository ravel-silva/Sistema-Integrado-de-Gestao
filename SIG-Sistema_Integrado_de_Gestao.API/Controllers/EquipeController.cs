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
                return Conflict(new {prefixo = dto.Prefixo,dataDaCriacao = dto.DataCriacao, mensagem = ex.Message });
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
        
    }
}
