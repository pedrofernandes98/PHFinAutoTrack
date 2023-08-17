using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PHFinAutoTrack.Application.DTOs;
using PHFinAutoTrack.Application.Interfaces;

namespace PHFinAutoTrack.API.Controllers
{
    [Route("/api/v1/lancamentos")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoService _lancamentoService;

        public LancamentoController(ILancamentoService lancamentoService,
                                    IMapper mapper)
        {
            _lancamentoService = lancamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var lancamentos = await _lancamentoService.GetAllAsync();
            if (lancamentos == null) return NotFound();
            return Ok(lancamentos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var lancamento = await _lancamentoService.GetByIdAsync(id);
            if (lancamento == null) return NotFound("Lançamento não foi encontrado.");
            return Ok(lancamento);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LancamentoDTO lancamentoDto)
        {
            if (lancamentoDto == null) return BadRequest();
            var lancamento = await _lancamentoService.CreateAsync(lancamentoDto);
            return Ok(lancamento);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] LancamentoDTO lancamentoDTO)
        {
            if (lancamentoDTO == null) return BadRequest();
            if (id != lancamentoDTO.Id) return BadRequest();
            var lancamento = await _lancamentoService.UpdateAsync(lancamentoDTO);
            return Ok(lancamento);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucess = await _lancamentoService.DeleteAsync(id);

            if(!sucess) return new StatusCodeResult(500);
            return Ok("Lançamento excluído com sucesso!");
        }

    }
}
