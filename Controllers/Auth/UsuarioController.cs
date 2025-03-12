using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Solicitacao_de_Material.Data.Dtos.Auth;
using Solicitacao_de_Material.Model.Auth;
using Solicitacao_de_Material.Services;

namespace Solicitacao_de_Material.Controllers.Auth
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        
        private UserService _Service;

        public UsuarioController(UserService service)
        {
            _Service = service;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CreateUsuario([FromBody] CreateUsuarioDto UsuarioDto)
        {
            await _Service.CadastroUser(UsuarioDto);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _Service.Login(loginDto);
            return Ok(new {Token = token});
        }
        [HttpGet] // so para teste, rever o codigo
        public IActionResult Get()
        {
           
            var lista = _Service.ListaDeUsuarios();
            return Ok(lista);
        }
    }
}
