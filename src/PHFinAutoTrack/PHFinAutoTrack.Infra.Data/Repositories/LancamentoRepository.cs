using Microsoft.EntityFrameworkCore;
using PHFinAutoTrack.Domain.Entities;
using PHFinAutoTrack.Domain.Interfaces;
using PHFinAutoTrack.Infra.Data.Context;

namespace PHFinAutoTrack.Infra.Data.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public readonly ApplicationDbContext _context;

        public LancamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lancamento>> GetAllAsync()
        {
            return await _context.Lancamentos
                .Include(l => l.Categoria)
                .OrderByDescending(l => l.DataLancamento)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Lancamento> GetByIdAsync(Guid id)
        {
            return await _context.Lancamentos
                .Include(l => l.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Lancamento> CreateAsync(Lancamento lancamento)
        {
            _context.Add(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<Lancamento> UpdateAsync(Lancamento lancamento)
        {
            _context.Update(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var lancamento = await GetByIdAsync(id);

            if(lancamento != null)
            {
                _context.Remove(lancamento);
                var sucess = await _context.SaveChangesAsync();
                return sucess == 1;
            }

            return false;
        }

    }
}
