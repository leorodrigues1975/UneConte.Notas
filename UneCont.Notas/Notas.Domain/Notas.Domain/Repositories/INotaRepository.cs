using Notas.Domain.Entities;


namespace Notas.Domain.Repositories
{
    public interface INotaRepository
    {
        Task AddAsync(NotaFiscal nota);
        Task<IEnumerable<NotaFiscal>> GetAllAsync();
        Task <NotaFiscal> ObterPorId(Guid id);
        Task Atualizar(NotaFiscal Nota);
        Task Deletar(Guid id);
    }
}
