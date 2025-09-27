using Notas.Application.Dtos;
using Notas.Application.Interfaces;
using Notas.Domain.Entities;
using Notas.Domain.Repositories;
using System.Threading.Tasks;

namespace Notas.Application.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _repository;

        public NotaService(INotaRepository repository)
        {
            _repository = repository;
        }

        public async Task Atualizar(CreateNotaDto dto)
        {
            if (dto.Valor <= 0) throw new ArgumentException("Valor deve ser maior que 0.");
            NotaFiscal nota = new NotaFiscal(dto.Id, dto.Numero, dto.Cliente, dto.Valor, dto.DataEmissao, dto.DataCadastro);

            _repository.Atualizar(nota);
                        
        }

        public async Task<NotaDto> CreateAsync(CreateNotaDto dto)
        {
            if (dto.Valor <= 0) throw new ArgumentException("Valor deve ser maior que 0.");

            // Verifica duplicidade
            var Notas = await _repository.GetAllAsync();

            if (Notas.Any(n => n.Numero == dto.Numero)) throw new ArgumentException( "Já existe uma nota com esse número.");
            
            var nota = new NotaFiscal(dto.Id, dto.Numero, dto.Cliente, dto.Valor, dto.DataEmissao, DateTime.Now);
            await _repository.AddAsync(nota);

            return new NotaDto
            {
                Id = nota.Id,
                Numero = nota.Numero,
                Cliente = nota.Cliente,
                Valor = nota.Valor,
                DataEmissao = nota.DataEmissao,
                DataCadastro = nota.DataCadastro
            };
        }

        public async Task Deletar(Guid id)
        {
            _repository.Deletar(id);
        }

        public async Task<IEnumerable<NotaDto>> GetAllAsync()
        {
            var notas = await _repository.GetAllAsync();
            return notas.Select(n => new NotaDto
            {
                Id = n.Id,
                Numero = n.Numero,
                Cliente = n.Cliente,
                Valor = n.Valor,
                DataEmissao = n.DataEmissao,
                DataCadastro = n.DataCadastro
            });
        }

        public async Task<NotaFiscal> ObterPorId(Guid id)
        {
           return await _repository.ObterPorId(id);
        }
                
    }
}
