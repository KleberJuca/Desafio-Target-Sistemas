namespace Desafio_Target_Sistemas.Models.Response
{
    public class ComissaoResponse
    {
        public string Vendedor { get; set; } = string.Empty;
        public decimal TotalVendido { get; set; }
        public decimal TotalComissao { get; set; }
    }
}
