using AutoMapper;
using PHFinAutoTrack.Application.DTOs;
using PHFinAutoTrack.Application.Interfaces;
using PHFinAutoTrack.Domain.Entities;
using PHFinAutoTrack.Domain.Interfaces;

namespace PHFinAutoTrack.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        public readonly ICategoriaRepository _repository;
        public readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoriaDTO>>(await _repository.GetAllAsync());
        }

        public async Task<CategoriaDTO> GetById(Guid id)
        {
            return _mapper.Map<CategoriaDTO>(await _repository.GetByIdAsync(id));
        }

        public async Task<CategoriaDTO> CreateAsync(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            return _mapper.Map<CategoriaDTO>(await _repository.CreateAsync(categoriaEntity));
        }

        public async Task<CategoriaDTO> UpdateAsync(CategoriaDTO categoriaDTO)
        {
            var categoriaEntity = _mapper.Map<Categoria>(categoriaDTO);
            return _mapper.Map<CategoriaDTO>(await _repository.UpdateAsync(categoriaEntity));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
