using Notas.Application.Dtos;
using Notas.Domain.Entities;

namespace Notas.Application.Interfaces
{
    public interface INotaService
    {
        Task<NotaDto> CreateAsync(CreateNotaDto dto);
        Task<IEnumerable<NotaDto>> GetAllAsync();

        Task<NotaFiscal> ObterPorId(Guid id);
        Task Atualizar(CreateNotaDto dto);
        Task Deletar(Guid id);
    }
}
