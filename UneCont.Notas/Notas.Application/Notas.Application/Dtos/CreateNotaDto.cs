using System.ComponentModel.DataAnnotations;

namespace Notas.Application.Dtos
{
    public class CreateNotaDto
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        public string Cliente { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que 0.")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }
    }
}
