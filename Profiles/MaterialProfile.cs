using AutoMapper;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<CreateMaterialDto, Material>();
            CreateMap<Material, ReadMaterialDto>();
            CreateMap<UpdateMaterialDto, Material>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => 
                srcMember != null && !(srcMember is string str && string.IsNullOrWhiteSpace(str))));
               
        }
    }
}
