using Microsoft.AspNetCore.Mvc;
using PHFinAutoTrack.Application.DTOs;
using PHFinAutoTrack.Application.Interfaces;
using System.Net;

namespace PHFinAutoTrack.API.Controllers
{
    [Route("/api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        public readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categorias = await _categoriaService.GetAllAsync();
            if(categorias == null) return NotFound();
            return Ok(categorias);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null) return NotFound("Categoria não foi encontrada.");
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null) return BadRequest();
            var categoria = await _categoriaService.CreateAsync(categoriaDTO);
            return Ok(categoria);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id) return BadRequest();
            if (categoriaDTO == null) return BadRequest();
            var categoria = await _categoriaService.UpdateAsync(categoriaDTO);
            return Ok(categoria);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucess = await _categoriaService.DeleteAsync(id);

            if (!sucess) return new StatusCodeResult(500);
            return Ok("Categoria excluída com sucesso!");
        }

    }
}
