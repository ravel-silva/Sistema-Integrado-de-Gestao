using Microsoft.EntityFrameworkCore;
using Sistema_Integrado_de_Gestao.Domain.Entities;
using Sistema_Integrado_de_Gestao.Domain.Interfaces;
using Sistema_Integrado_de_Gestao.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Integrado_de_Gestao.Infra.Data.Repositories
{
    // configurar injeção
    public class EquipeRepository : IEquipeRepository
    {
        private readonly AppDbContext _context;

        public EquipeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Equipe> Incluir(Equipe equipe)
        {
            _context.Equipe.Add(equipe);
            await _context.SaveChangesAsync();
            return equipe;
        }
        public async Task<Equipe> AlterarPorPrefixo(Equipe equipe)
        {
            _context.Equipe.Update(equipe);
            await _context.SaveChangesAsync();
            return equipe;
        }
        public async Task<Equipe> AlterarPorId(Equipe equipe)
        {
            _context.Equipe.Update(equipe);
            await _context.SaveChangesAsync();
            return equipe;
        }

        public async Task<Equipe> Excluir(int id)
        {
            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe != null)
            {
                _context.Equipe.Remove(equipe);
                await _context.SaveChangesAsync();
                return equipe;
            }
            return null;
        }


        public async Task<bool> SalveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Equipe> SelecionarPorPrefixo(string prefixo)
        {
            return await _context.Equipe.Where(equipe => equipe.Prefixo == prefixo).FirstOrDefaultAsync();
        }
        public async Task<Equipe> SelecionarPorId(string prefixo)
        {
            return await _context.Equipe.Where(equipe => equipe.Prefixo == prefixo).FirstOrDefaultAsync();
        }
        public async Task<Equipe> SelecionarPorId(int id)
        {
            return await _context.Equipe.Where(equipe => equipe.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Equipe>> SelecionarTodos()
        {
            return await _context.Equipe.ToListAsync();
        }
    }
}
