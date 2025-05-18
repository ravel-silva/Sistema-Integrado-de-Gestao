using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;
using Solicitacao_de_Material.Services;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SolicitacaoController : ControllerBase
    {
        private RequisicaoDeMaterialService _service;
        
        public SolicitacaoController(RequisicaoDeMaterialService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CreateSolicitacao([FromBody] CreateRequisicaoDeMaterialDto requisicao)
        {

            if (requisicao == null || requisicao.Materiais == null || !requisicao.Materiais.Any())
            {
                return BadRequest("A lista de materiais não pode estar vazia.");
            }
           
            _service.CreateRequisicaoDeMaterial(requisicao);

            return Ok();
        }
        [HttpGet]
        public IActionResult Requisicoes([FromQuery]PaginationParameters parameters)
        {
            if (_service.ViewRequisicoes(parameters) == null || !_service.ViewRequisicoes(parameters).Any())
            {
                return NotFound("Não há solicitações cadastradas no sistema.");
            }
            var solicitacoes = _service.ViewRequisicoes(parameters);

            return Ok(solicitacoes);
        }
        [HttpGet("{id}")]
        public IActionResult RequisicoesId(int id)
        {
            if (_service.ViewRequisicoesId(id) == null || !_service.ViewRequisicoesId(id).Any())
            {
                return NotFound("Não há solicitações cadastradas para a equipe informada.");
            }
            var solicitacoes = _service.ViewRequisicoesId(id);
            return Ok(solicitacoes);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSolicitacao(int id)
        {
            if(_service.DeleteRequisicao(id) == false)
            {
                return NotFound("Solicitação não encontrada.");
            }
            _service.DeleteRequisicao(id);
            return Ok();
        }
        [HttpPut ("{id}")]
        public IActionResult UpdateRequisicoes(int id, [FromBody] UpdataRequisicaoDeMaterialDto requisicao)
        {
            if (requisicao == null)
            {
                return BadRequest("Requisição não pode ser nula.");
            }
            _service.UpdateRequisicao(id, requisicao);
            return Ok();
        }
    }
}
