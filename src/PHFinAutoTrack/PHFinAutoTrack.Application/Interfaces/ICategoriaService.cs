using PHFinAutoTrack.Application.DTOs;
using PHFinAutoTrack.Domain.Entities;

namespace PHFinAutoTrack.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDTO>> GetAll();
        Task<CategoriaDTO> GetById(Guid id);
        Task<CategoriaDTO> CreateAsync(CategoriaDTO categoriaDTO);
        Task<CategoriaDTO> UpdateAsync(CategoriaDTO categoriaDTO);
        Task<bool> DeleteAsync(Guid id);
    }
}
