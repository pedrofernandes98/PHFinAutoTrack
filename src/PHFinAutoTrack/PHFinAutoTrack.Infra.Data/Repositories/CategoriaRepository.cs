using Microsoft.EntityFrameworkCore;
using PHFinAutoTrack.Domain.Entities;
using PHFinAutoTrack.Domain.Interfaces;
using PHFinAutoTrack.Infra.Data.Context;

namespace PHFinAutoTrack.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _context.Categorias.OrderBy(c => c.Nome).AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(Guid id)
        {
            return await _context.Categorias
                                .Include(c => c.Lancamentos)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            _context.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var categoria = await GetByIdAsync(id);

            if(categoria != null)
            {
                _context.Remove(categoria);
                var sucess = await _context.SaveChangesAsync();
                return sucess == 1;
            }

            return false;
        }
    }
}
