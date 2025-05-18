using AutoMapper;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Profiles
{
    public class RequisicaoDeMaterialProfile : Profile
    {
        public RequisicaoDeMaterialProfile()
        {

            CreateMap<CreateListMaterialDto, ListMaterial>();

            CreateMap<CreateRequisicaoDeMaterialDto, RequisicaoDeMaterial>()
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<RequisicaoDeMaterial, ReadRequisicaoDeMaterialDto>()
                .ForMember(dest => dest.EquipeNome, opt => opt.MapFrom(src => src.Equipe.Prefixo));

            CreateMap<ListMaterial, ReadMaterialDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Material.Id))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Material.Codigo))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Material.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Material.Descricao))
                .ForMember(dest => dest.Unidade, opt => opt.MapFrom(src => src.Material.Unidade))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Material.Status));

            CreateMap<UpdataRequisicaoDeMaterialDto, RequisicaoDeMaterial>()
                .ForMember(dest => dest.Materiais, opt => opt.Ignore());

            CreateMap<UpdateMaterialDto, ListMaterial>();
        }
    }
}
