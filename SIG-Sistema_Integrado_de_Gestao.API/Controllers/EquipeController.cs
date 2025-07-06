using Microsoft.AspNetCore.Mvc;
using Sistema_Integrado_de_Gestao.Application.Dtos;
using Sistema_Integrado_de_Gestao.Application.Services;
using Sistema_Integrado_de_Gestao.Domain.Entities;

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
        public async Task<ActionResult<EquipeDTO>> CadastroDeEquipe([FromBody]EquipeDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados inválidos.");
            }
            // verificar se o usuario e cadastrado
            //aqui
            var equipe = await _equipeService.Incluir(dto);
            return Ok(equipe);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipeDTO>>> SelecionarTodos()
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
