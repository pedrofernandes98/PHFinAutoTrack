using AutoMapper;
using PHFinAutoTrack.Application.DTOs;
using PHFinAutoTrack.Application.Interfaces;
using PHFinAutoTrack.Domain.Entities;
using PHFinAutoTrack.Domain.Interfaces;

namespace PHFinAutoTrack.Application.Services
{
    public class LancamentoService : ILancamentoService
    {
        public readonly ILancamentoRepository _repository;
        public readonly IMapper _mapper; 

        public LancamentoService(ILancamentoRepository repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LancamentoDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<LancamentoDTO>>(await _repository.GetAllAsync());
        }

        public async Task<LancamentoDTO> GetByIdAsync(Guid id)
        {
            return _mapper.Map<LancamentoDTO>(await _repository.GetByIdAsync(id));
        }

        public async Task<LancamentoDTO> CreateAsync(LancamentoDTO lancamento)
        {
            var lancamentoEntity = _mapper.Map<Lancamento>(lancamento);
            return _mapper.Map<LancamentoDTO>(await _repository.CreateAsync(lancamentoEntity));
        }

        public async Task<LancamentoDTO> UpdateAsync(LancamentoDTO lancamento)
        {
            var lancamentoEntity = _mapper.Map<Lancamento>(lancamento);
            return _mapper.Map<LancamentoDTO>(await _repository.UpdateAsync(lancamentoEntity));
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
