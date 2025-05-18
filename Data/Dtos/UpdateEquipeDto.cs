using System.ComponentModel.DataAnnotations;

namespace Sistema_Integrado_de_Gestão.Data.Dtos
{
    public class UpdateEquipeDto
    {
        public string Prefixo { get; set; }
        public DateTime DataModificacao { get; set; } = DateTime.Now;
    }
}
