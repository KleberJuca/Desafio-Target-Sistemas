using System.ComponentModel.DataAnnotations;

namespace Desafio_Target_Sistemas.Models.Request
{
    public class VendaRequest
    {
        public string Vendedor { get; set; } = string.Empty;
        public decimal Valor { get; set; }
    }
}
