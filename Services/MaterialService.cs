using AutoMapper;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class MaterialService
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public MaterialService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Add Material to the database
        public void CreateMaterial(CreateMaterialDto MaterialDto)
        {
            var material = _mapper.Map<Material>(MaterialDto);
            _context.Materiais.Add(material);
            _context.SaveChanges();
        }

        // Get all Materials from the database
        public IEnumerable<ReadMaterialDto> GetMaterials(PaginationParameters parameters)
        {
            var materiais = _context.Materiais
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();
            var materiaisDto = _mapper.Map<List<ReadMaterialDto>>(materiais);
            return materiaisDto.ToList();
        }

        // Get a Material by Id from the database
        public ReadMaterialDto? GetMaterialById(int id)
        {
            var materiais = _context.Materiais.FirstOrDefault(material => material.Id == id);
            var materiaisDto = _mapper.Map<ReadMaterialDto>(materiais);
            return materiaisDto;
        }

        // Update a Material in the database
        public bool UpdateMaterial(UpdateMaterialDto updateMaterialDto)
        {
            var material = _context.Materiais.FirstOrDefault(material => material.Id == updateMaterialDto.Id);
        
            _mapper.Map(updateMaterialDto, material);
            _context.SaveChanges();
            return true;
        }

        // Delete a Material from the database
        public bool DeleteMaterial(int id)
        {
            var material = _context.Materiais.FirstOrDefault(material => material.Id == id);
            if (material == null)
            {
                return false;
            }
            _context.Materiais.Remove(material);
            _context.SaveChanges();
            return true;
        }
    }
}
