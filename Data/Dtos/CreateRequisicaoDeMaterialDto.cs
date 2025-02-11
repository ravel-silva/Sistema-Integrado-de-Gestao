﻿using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Data.Dtos
{
    public class CreateRequisicaoDeMaterialDto
    {
        public int EquipeId { get; set; }
        public string Status { get; set; } = "Ativa"; // Status da requisição (ex: Ativo, Cancelado, Concluído)
        public DateTime DateTime { get; set; } = DateTime.Now; // Data e hora em que a requisição foi feita
        public ICollection<CreateListMaterialDto> Materiais { get; set; }
    }
}