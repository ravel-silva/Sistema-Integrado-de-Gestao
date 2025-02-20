using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Solicitacao_de_Material.Controllers.Auth
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "NivelDeAcessoBasico")]
        public IActionResult AcessoBasico()
        {
            return Ok();
        }

        [HttpGet]
        [Authorize(Policy = "NivelDeAcessoAdmin")]
        public IActionResult AcessoAdmin()
        {
            return Ok();
        }
    }
}
