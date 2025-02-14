using Microsoft.AspNetCore.Identity;
using Solicitacao_de_Material.Data.Dtos.Auth;
using Solicitacao_de_Material.Model.Auth;

namespace Solicitacao_de_Material.Services
{
    public class UserService
    {
        private UserManager<Usuario> _userManege;
        private SignInManager<Usuario> _singInManager;

        public UserService(UserManager<Usuario> userManege, SignInManager<Usuario> singInManager)
        {
            _userManege = userManege;
            _singInManager = singInManager;
        }

        public async Task CadastroUser(CreateUsuarioDto UsuarioDto)
        {
            var usuario = new Usuario
            {
                UserName = UsuarioDto.Username,
                Matricula = UsuarioDto.Matricula,
            };
            IdentityResult result = await _userManege.CreateAsync(usuario, UsuarioDto.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException("Erro ao criar o usuario");
            }
            

        }

        public async Task Login(LoginDto loginDto)
        {
            await _singInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
            var resultado = await _singInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Erro ao logar");
            }
        }
    }
}
