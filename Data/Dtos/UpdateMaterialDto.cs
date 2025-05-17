using System.ComponentModel.DataAnnotations;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class UpdateMaterialDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o codigo")]
        [Range(100000, 99999999, ErrorMessage = "O código deve ter entre 6 e 8 dígitos")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Informe o nome do material")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe a descrição do material")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe a quantidade do material")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Informe o unidade do material, ex: UN, M, KG, PÇ")]
        public string Unidade { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime DataModificacao { get; set; } = DateTime.Now;
    }
}
