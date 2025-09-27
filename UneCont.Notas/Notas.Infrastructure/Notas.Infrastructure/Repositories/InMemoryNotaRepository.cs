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

        public async Task<NotaFiscal> ObterPorId(Guid id)
        {
            return _store.FirstOrDefault(n => n.Id == id);
        }

        public Task Atualizar(NotaFiscal nota)
        {
            var existente = ObterPorId(nota.Id);
            if (existente != null)
            {
                // "remover" significa recriar a coleção sem esse item
                Deletar(nota.Id);
                _store.Add(nota);
            }
            return Task.CompletedTask;
        }

        public Task Deletar(Guid id)
        {
            var notasRestantes = _store.Where(n => n.Id != id).ToList();

            // recria a bag sem o item excluído
            while (_store.TryTake(out _)) { } // esvazia

            foreach (var n in notasRestantes)
                _store.Add(n);
            return Task.CompletedTask;
        }

    }
}
