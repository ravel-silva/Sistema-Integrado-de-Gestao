using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Data.Dtos;
using Solicitacao_de_Material.Model;

namespace Solicitacao_de_Material.Services
{
    public class RequisicaoDeMaterialService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public RequisicaoDeMaterialService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateRequisicaoDeMaterial(CreateRequisicaoDeMaterialDto requisicao)
        {
            var novaRequisicao = _mapper.Map<RequisicaoDeMaterial>(requisicao);
            _context.RequisicoesDeMaterial.Add(novaRequisicao);
            _context.SaveChanges();
        }
        public ICollection<ReadRequisicaoDeMaterialDto> ViewRequisicoes(PaginationParameters parameters)
        {
            var requisicoes = _context.RequisicoesDeMaterial
                .Include(r => r.Equipe)
                .Include(r => r.Materiais)
                .ThenInclude(m => m.Material)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize).ToList();
            return _mapper.Map<ICollection<ReadRequisicaoDeMaterialDto>>(requisicoes);
        }
        public ICollection<ReadRequisicaoDeMaterialDto> ViewRequisicoesId(int id)
        {
            var requisicao = _context.RequisicoesDeMaterial
                .Include(r => r.Equipe)
                .Include(r => r.Materiais)
                .ThenInclude(m => m.Material)
                .Where(r => r.EquipeId == id)
                .ToList();
            return _mapper.Map<ICollection<ReadRequisicaoDeMaterialDto>>(requisicao);
        }
        public bool DeleteRequisicao(int id)
        {
            var requisicoes = _context.RequisicoesDeMaterial
                .Include(r => r.Materiais)
                .FirstOrDefault(r => r.Id == id);
            if (requisicoes == null)
            {
                return false;
            }
            _context.RequisicoesDeMaterial.Remove(requisicoes);
            _context.SaveChanges();
            return true;
        }
        public void UpdateRequisicao(int id, UpdataRequisicaoDeMaterialDto requisicao)
        {
            var requisicaoExistente = _context.RequisicoesDeMaterial
                .Include(r => r.Materiais)
                .FirstOrDefault(r => r.Id == id);
            if (requisicaoExistente == null)
            {
                return;
            }

            _mapper.Map(requisicao, requisicaoExistente);
            requisicaoExistente.DateTime = DateTime.Now;
            requisicaoExistente.Materiais.Clear();
            var materiaisAtualizados = _mapper.Map<ICollection<ListMaterial>>(requisicao.Materiais);
            foreach (var material in materiaisAtualizados)
            {
                requisicaoExistente.Materiais.Add(material);
            }
            _context.SaveChanges();
        }
    }
}
