using Notas.Domain.Entities;
using Notas.Domain.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notas.Infrastructure.Repositories
{
    public class InMemoryNotaRepository : INotaRepository
    {
        private readonly ConcurrentBag<NotaFiscal> _store = new();

        public Task AddAsync(NotaFiscal nota)
        {
            _store.Add(nota);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<NotaFiscal>> GetAllAsync()
        {
            // retorna cópia segura
            return Task.FromResult<IEnumerable<NotaFiscal>>(_store.ToArray().OrderBy(n => n.DataCadastro));
        }
    }
}
