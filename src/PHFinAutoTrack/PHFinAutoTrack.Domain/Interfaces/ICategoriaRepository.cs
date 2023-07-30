using PHFinAutoTrack.Domain.Entities;

namespace PHFinAutoTrack.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllAsync();

        Task<Categoria> GetByIdAsync(Guid id);

        Task<Categoria> CreateAsync(Categoria categoria);

        Task<Categoria> UpdateAsync(Categoria categoria);

        Task<bool> DeleteAsync(Guid id);
    }
}
