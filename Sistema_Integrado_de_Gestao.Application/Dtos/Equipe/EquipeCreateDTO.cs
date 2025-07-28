using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Integrado_de_Gestao.Application.Dtos.Equipe
{
    public class EquipeCreateDTO
    {
        [Required(ErrorMessage = "O prefixo e obrigatorio")]
        [MinLength(6, ErrorMessage = "O prefixo deve ter no mínimo 6 caracteres.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "O prefixo não pode conter espaços em branco.")]
        [SwaggerSchema("Prefixo da Equipe, Exemplo 'MA-GNF-A001M'")]
        public string Prefixo { get; set; }


        [Required(ErrorMessage = "A Data de Criação é obrigatoria")]
        [DataType(DataType.Date, ErrorMessage = "A Data de Criação deve ser uma data válida.")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
