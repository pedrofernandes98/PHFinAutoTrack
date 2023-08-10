using PHFinAutoTrack.Application.DTOs;

namespace PHFinAutoTrack.Application.Interfaces
{
    public interface ILancamentoService
    {
        Task<IEnumerable<LancamentoDTO>> GetAllAsync();

        Task<LancamentoDTO> GetByIdAsync(Guid id);

        Task<LancamentoDTO> CreateAsync(LancamentoDTO lancamento);

        Task<LancamentoDTO> UpdateAsync(LancamentoDTO lancamento);

        Task<bool> DeleteAsync(Guid id);
    }
}
