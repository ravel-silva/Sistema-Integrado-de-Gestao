using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos.Auth
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
