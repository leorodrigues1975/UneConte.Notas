using Notas.Application.Dtos;
using Notas.Application.Interfaces;
using Notas.Domain.Entities;
using Notas.Domain.Repositories;

namespace Notas.Application.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _repository;

        public NotaService(INotaRepository repository)
        {
            _repository = repository;
        }

        public async Task<NotaDto> CreateAsync(CreateNotaDto dto)
        {
            if (dto.Valor <= 0) throw new ArgumentException("Valor deve ser maior que 0.");

            // Verifica duplicidade
            var Notas = await _repository.GetAllAsync();

            if (Notas.Any(n => n.Numero == dto.Numero)) throw new ArgumentException( "Já existe uma nota com esse número.");
            
            var nota = new NotaFiscal(dto.Numero, dto.Cliente, dto.Valor, dto.DataEmissao);
            await _repository.AddAsync(nota);

            return new NotaDto
            {
                Numero = nota.Numero,
                Cliente = nota.Cliente,
                Valor = nota.Valor,
                DataEmissao = nota.DataEmissao,
                DataCadastro = nota.DataCadastro
            };
        }

        public async Task<IEnumerable<NotaDto>> GetAllAsync()
        {
            var notas = await _repository.GetAllAsync();
            return notas.Select(n => new NotaDto
            {
                Numero = n.Numero,
                Cliente = n.Cliente,
                Valor = n.Valor,
                DataEmissao = n.DataEmissao,
                DataCadastro = n.DataCadastro
            });
        }
    }
}
