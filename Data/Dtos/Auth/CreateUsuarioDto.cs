using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos.Auth
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Matricula { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")] // comparaçao com o Password
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime DataDeCadastro { get; set; } = DateTime.Now;
        [Required]
        public string NivelDeAcesso { get; set; }

    }
}
