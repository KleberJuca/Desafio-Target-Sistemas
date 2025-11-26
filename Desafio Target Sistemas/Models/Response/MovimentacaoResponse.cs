using Desafio_Target_Sistemas.Models.Request;

namespace Desafio_Target_Sistemas.Models.Response
{
    public class MovimentacaoResponse
    {
        public Guid IdMovimentacao { get; set; }
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public string DescricaoMovimento { get; set; } = string.Empty;
        public int EstoqueFinal { get; set; }
        public List<Produto> EstoqueAtualizado { get; set; } = new();
    }
}
