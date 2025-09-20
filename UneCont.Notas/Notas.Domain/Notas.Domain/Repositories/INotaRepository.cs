using Notas.Domain.Entities;


namespace Notas.Domain.Repositories
{
    public interface INotaRepository
    {
        Task AddAsync(NotaFiscal nota);
        Task<IEnumerable<NotaFiscal>> GetAllAsync();
    }
}
