using System.ComponentModel.DataAnnotations;

namespace Sistema_Integrado_de_Gestão.Data.Dtos
{
    public class UpdateFuncionarioDto
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;
    }
}