using Notas.Application.Dtos;

namespace Notas.Application.Interfaces
{
    public interface INotaService
    {
        Task<NotaDto> CreateAsync(CreateNotaDto dto);
        Task<IEnumerable<NotaDto>> GetAllAsync();
    }
}
