using Microsoft.AspNetCore.Mvc;
using Notas.Application.Dtos;
using Notas.Application.Interfaces;
using Notas.Domain.Entities;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace UneCont.Notas.Api.Controllers
{
    [ApiController]
    [Route("api/notas")]
    public class NotasController : ControllerBase
    {
        private readonly INotaService _notaService;

        public NotasController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpPost]
        [Route("v1/criar")]
        public async Task<IActionResult> Criar([FromBody] CreateNotaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var result = await _notaService.CreateAsync(dto);
                return Ok(result);
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut()]
        [Route("v1/Atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] CreateNotaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _notaService.Atualizar(dto);
            return Ok(new { message = "Nota atualizada com sucesso!" });
        }

        [HttpDelete()]
        [Route("v1/Deletar/{id}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var nota = await _notaService.ObterPorId(id);
            if (nota == null) return NotFound();

            _notaService.Deletar(id);
            return Ok(new { message = "Nota excluída com sucesso!" });
        }

        [HttpGet]
        [Route("v1/listar")]
        public async Task<IActionResult> Listar()
        {
            var notas = await _notaService.GetAllAsync();
            return Ok(notas);
        }
    }
}
