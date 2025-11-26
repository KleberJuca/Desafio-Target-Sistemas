namespace Desafio_Target_Sistemas.Models.Response
{
    public class JurosResponse
    {
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public int DiasAtraso { get; set; }
        public decimal Juros { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
