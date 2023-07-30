using PHFinAutoTrack.Domain.Entities;

namespace PHFinAutoTrack.Domain.Interfaces
{
    public interface ILancamentoRepository
    {
        Task<IEnumerable<Lancamento>> GetAllAsync();

        Task<Lancamento> GetByIdAsync(Guid id);

        Task<Lancamento> CreateAsync(Lancamento lancamento);

        Task<Lancamento> UpdateAsync(Lancamento lancamento);

        Task<bool> DeleteAsync(Guid id);
    }
}
