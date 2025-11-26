using System.ComponentModel.DataAnnotations;

namespace Desafio_Target_Sistemas.Models.Request
{
    public class JurosRequest
    {
        [Range(0.01, double.MaxValue)]
        public decimal Valor { get; set; }

        public DateTime DataVencimento { get; set; }
    }
}
