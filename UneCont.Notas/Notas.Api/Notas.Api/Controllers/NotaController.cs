using Microsoft.AspNetCore.Mvc;
using Notas.Application.Dtos;
using Notas.Application.Interfaces;

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

        [HttpGet]
        [Route("v1/listar")]
        public async Task<IActionResult> Listar()
        {
            var notas = await _notaService.GetAllAsync();
            return Ok(notas);
        }
    }
}
