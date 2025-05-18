using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;
using Solicitacao_de_Material.Services;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelationShipEquipeFuncionarioController : ControllerBase
    {
        private RelationShipEquipeFuncionarioService _service;
        public RelationShipEquipeFuncionarioController(RelationShipEquipeFuncionarioService service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult CreateRelationship([FromBody] CreateRelationshipEquipeFuncionarioDto relationshipEquipeFuncionarioDto)
        {
            if (relationshipEquipeFuncionarioDto == null
                || relationshipEquipeFuncionarioDto.equipeId == 0
                || relationshipEquipeFuncionarioDto.funcionarioId == 0)
            {
                return BadRequest("Dados invalidos ou incompletos");
            }

            if (_service.CheckTeamEmployee(relationshipEquipeFuncionarioDto) != true)
            {
                return BadRequest("Equipe ou Funcionário não localizado");
            }
            // Verificar se um funcionário já está em uma equipe

            if (_service.CheckTeamEmployee(relationshipEquipeFuncionarioDto) != true)
            {
                return BadRequest("Funcionário já está em uma equipe");
            }
            // Criar o relacionamento
            _service.CreateRelationship(relationshipEquipeFuncionarioDto);

            return Ok();

        }

        [HttpGet]
        public IActionResult GetRelationship([FromQuery]PaginationParameters parameters)
        {
            if (_service.GetRelationship(parameters) == null || !_service.GetRelationship(parameters).Any())
            {
                return NotFound("Nenhum relacionamento localizado");
            }
            var relationship = _service.GetRelationship(parameters);
            return Ok(relationship);
        }
        [HttpGet("{id}")]
        public IActionResult GetRelationshipId(int id)
        {
            if (_service.GetRelationshipById(id) == null || !_service.GetRelationshipById(id).Any())
            {
                return NotFound("Nenhum relacionamento localizado");
            }
            var relationship = _service.GetRelationshipById(id);
            return Ok(relationship);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRelationship(int id)
        {
            if (!_service.DeleteRelationship(id))
            {
                return NotFound("Relacionamento não localizado");
            }
            return Ok("Relacionamento deletado com sucesso");
        }
    }

}
