using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;
using Solicitacao_de_Material.Services;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private TeamService _TeamService;
        public TeamController(AppDbContext context, TeamService teamService)
        {
            _TeamService = teamService;
        }
        // This method creates a team
        [HttpPost]
        public IActionResult CreateTeam([FromBody] CreateEquipeDto CadastroEquipeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_TeamService.VerificarEquipe(CadastroEquipeDto.Prefixo))
            {
                return BadRequest("Equipe já cadastrada");
            }

            try
            {
                _TeamService.CreateEquipe(CadastroEquipeDto);
                return Ok(new { message = "Equipe Criada com Sucesso.", Equipe = CadastroEquipeDto });
            }
            catch (DbUpdateException erro)
            {
                return StatusCode(500, $"Erro ao criar equipe.{erro.Message}");
            }
            catch (Exception erro)
            {
                return StatusCode(500, $"Erro desconhecido ao criar equipe.{erro.Message}");
            }
        }

        // This method returns the list of teams
        [HttpGet]
        public IActionResult GetTeams([FromQuery]PaginationParameters parameters)
        {
            var equipes = _TeamService.GetEquipe(parameters);
            if (equipes == null || !equipes.Any())
            {
                return NotFound("Não há equipes cadastradas no sistema.");
            }
            return Ok(equipes);

        }
        //this method returns the team by id
        [HttpGet("{id}")]
        public IActionResult GetTeamId(int id)
        {
            var equipe = _TeamService.GetEquipeId(id);

            if (equipe == null)
            {
                return NotFound("Equipe não localizada no sistema");
            }

            return Ok(equipe);
        }

        // This method deletes a team
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            if (!_TeamService.DeleleteEquipe(id))
            {
                return NotFound("Equipe não localizada no sistema");
            }
            return Ok("Equipe Deletada");
        }

    }
}
