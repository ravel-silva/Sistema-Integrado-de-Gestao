using Microsoft.AspNetCore.Identity;
using Solicitacao_de_Material.Data.Dtos.Auth;
using Solicitacao_de_Material.Model.Auth;

namespace Solicitacao_de_Material.Services
{
    public class UserService
    {
        private UserManager<Usuario> _userManege;
        private SignInManager<Usuario> _signInManager;

        public UserService(UserManager<Usuario> userManege, SignInManager<Usuario> signInManager)
        {
            _userManege = userManege;
            _signInManager = signInManager;
        }

        public async Task CadastroUser(CreateUsuarioDto UsuarioDto)
        {
            var usuario = new Usuario
            {
                UserName = UsuarioDto.Username,
                Matricula = UsuarioDto.Matricula,
                NivelDeAcesso = UsuarioDto.NivelDeAcesso
            };
            IdentityResult result = await _userManege.CreateAsync(usuario, UsuarioDto.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException("Erro ao criar o usuario");
            }
            

        }

        public async Task<string> Login(LoginDto loginDto)
        {
            await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
            var resultado = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Erro ao logar");
            }
            var token = await _userManege.GenerateUserTokenAsync(await _userManege.FindByNameAsync(loginDto.Username), "Default", "token");
            return token;
        }

        //visualizar todos os usuarios
        public async Task<IEnumerable<Usuario>> ListaDeUsuarios()
        {
            return _userManege.Users.ToList();
        }
    }
}
