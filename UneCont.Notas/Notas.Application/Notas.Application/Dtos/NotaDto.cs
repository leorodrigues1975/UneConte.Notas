

namespace Notas.Application.Dtos
{
    public class NotaDto
    {
        public int Numero { get; set; }
        public string Cliente { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
