
namespace Notas.Domain.Entities
{
    public class NotaFiscal
    {
        public Guid Id { get; private set; }
        public int Numero { get;  set; }
        public string Cliente { get;  set; }
        public decimal Valor { get;  set; }
        public DateTime DataEmissao { get;  set; }
        public DateTime DataCadastro { get;  set; }

        public NotaFiscal(Guid id, int numero, string cliente, decimal valor, DateTime dataEmissao, DateTime dataCadastro)
        {
            if (string.IsNullOrWhiteSpace(cliente)) throw new ArgumentException("Cliente obrigatório.", nameof(cliente));
            if (valor <= 0) throw new ArgumentException("Valor deve ser maior que zero.", nameof(valor));
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Numero = numero;
            Cliente = cliente;
            Valor = valor;
            DataEmissao = dataEmissao;
            DataCadastro = dataCadastro;
        }
    }
}
