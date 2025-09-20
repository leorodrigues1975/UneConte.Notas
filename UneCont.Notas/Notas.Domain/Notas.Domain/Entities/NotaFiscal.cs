
namespace Notas.Domain.Entities
{
    public class NotaFiscal
    {
        public int Numero { get; private set; }
        public string Cliente { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public NotaFiscal(int numero, string cliente, decimal valor, DateTime dataEmissao)
        {
            if (string.IsNullOrWhiteSpace(cliente)) throw new ArgumentException("Cliente obrigatório.", nameof(cliente));
            if (valor <= 0) throw new ArgumentException("Valor deve ser maior que zero.", nameof(valor));
            Numero = numero;
            Cliente = cliente;
            Valor = valor;
            DataEmissao = dataEmissao;
            DataCadastro = DateTime.UtcNow; 
        }
    }
}
