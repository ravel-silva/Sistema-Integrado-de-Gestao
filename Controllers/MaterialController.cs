using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;
using Solicitacao_de_Material.Services;

namespace Solicitacao_de_Material.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : ControllerBase
    {
        public MaterialService _service;
        public MaterialController(MaterialService service)
        {
            _service = service;
        }

        [HttpPost]
       // [Authorize(Policy = "Administrador")]
        public IActionResult CreateMaterial([FromBody] CreateMaterialDto materialDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            _service.CreateMaterial(materialDto);
            return Ok();
        }

        [HttpGet]
        //[Authorize(Policy = "Basico")]
        public IActionResult GetMaterials([FromQuery]PaginationParameters parameters)
        {
            if (_service.GetMaterials(parameters) == null || !_service.GetMaterials(parameters).Any())
            {
                return NotFound("Nenhum material localizado");
            }
            return Ok(_service.GetMaterials(parameters));
        }

        [HttpGet("{id}")]
       // [Authorize(Policy = "Basico")]
        public IActionResult GetMaterialById(int id)
        {
            if (_service.GetMaterialById(id) == null)
            {
                return NotFound("Material não localizado");
            }
            return Ok(_service.GetMaterialById(id));
        }

        [HttpPut("{id}")]
        //[Authorize(Policy = "Administrador")]
        public IActionResult UpdateMaterial(int id, [FromBody] UpdateMaterialDto updateMaterialDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != updateMaterialDto.Id)
            {
                return BadRequest("Id inválido");
            }
            if (!_service.UpdateMaterial(updateMaterialDto))
            {
                return NotFound("Material não localizado");
            }
            return Ok("Material atualizado com sucesso");
        }

        [HttpDelete("{id}")]
       // [Authorize(Policy = "Administrador")]
        public IActionResult DeleteMaterial(int id)
        {
            if (!_service.DeleteMaterial(id))
            {
                return NotFound("Material não localizado");
            }
            return Ok("Material deletado com sucesso");
        }
        
    }
}
