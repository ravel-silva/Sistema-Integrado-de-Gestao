using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Domain.Entities
{
    internal class Material
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o codigo")]
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
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public ICollection<ListMaterial> ListMateriais { get; set; }
    }
}
